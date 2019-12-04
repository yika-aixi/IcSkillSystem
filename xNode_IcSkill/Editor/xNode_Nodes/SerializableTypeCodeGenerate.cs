
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_Nodes
{
    public class SerializableTypeCodeGenerate:EditorWindow
    {
        private static string _defaultNameSpace = "CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes";

        private const string NameMark = "%NAME%";
        private const string TypeMark = "%TYPE%";
        private const string NameSpaceMark = "%NAMESPACE%";
        private const string IsChangeMark = "%ISCHANGE%";
        private const string AssemblyMark = "%ASSEMBLY%";
           
        const string ValueNodeTemplateName = "ValueNodeTemplate.cs";

        private static string _templateContent;

        private static Dictionary<string,bool> _generateTypeAqNameMap;
        private static Dictionary<Type,bool> _generateTypeMap;
        private static List<bool> _groupStates;
        private static IEnumerable<IGrouping<string, KeyValuePair<Type, bool>>> _assemblyGroup;
        
        private static void _loadTemple()
        {
            var guids = AssetDatabase.FindAssets(ValueNodeTemplateName);

            if (guids.Length == 0)
            {
                return;
            }

            var path = AssetDatabase.GUIDToAssetPath(guids[0]);

            var textAssets = AssetDatabase.LoadAssetAtPath<TextAsset>(path);

            _templateContent = textAssets.text;

            Resources.UnloadAsset(textAssets);
        }

        private static string GenerateSavePath
        {
            get => EditorPrefs.GetString(_getKey(nameof(GenerateSavePath)));
            set => EditorPrefs.SetString(_getKey(nameof(GenerateSavePath)),value);
        }

        public static string NameSpace
        {
            get
            {
                var str = EditorPrefs.GetString(_getKey(nameof(NameSpace)));
                if (string.IsNullOrWhiteSpace(str))
                {
                    NameSpace = _defaultNameSpace;
                    return NameSpace;
                }
                return str;
            }
            
            set => EditorPrefs.SetString(_getKey(nameof(NameSpace)),value);
        }

        [MenuItem("Icarus/IcSkillSystem/ValueNode Code Generate")]
        static void _open()
        {
            var wind = GetWindow<SerializableTypeCodeGenerate>();
            wind.titleContent = new GUIContent("ValueNode Generate");
            _init();
        }

        private static void _init()
        {
            _generateTypeAqNameMap = new Dictionary<string, bool>();
            _generateTypeAqNameMap =
                SerializationUtil.ToValue<Dictionary<string, bool>>(
                    EditorPrefs.GetString(_getKey(nameof(_generateTypeAqNameMap))));

            var runtimeTypes = TypeUtil.AllTypes
                .Where(x => x.CustomAttributes.All(y => y.AttributeType != typeof(ObsoleteAttribute)))
                .Where(x => !x.IsPointer)
                .Where(x => !typeof(Delegate).IsAssignableFrom(x))
                .Where(x => !typeof(Exception).IsAssignableFrom(x))
                .Where(x => !typeof(Attribute).IsAssignableFrom(x))
                .Where(x => !x.IsGenericType)
                .Where(x => !x.IsAbstract)
                .Where(x =>
                {
                    if (x.IsSealed)
                    {
                        return x.IsSealed && x.IsPublic || x.IsPublic;
                    }

                    return x.IsPublic;
                })
                .Where(x => x.IsValueType || x.IsEnum ||
                            x.IsClass && x.CustomAttributes.Any(y => y.AttributeType == typeof(SerializableAttribute)) ||
                            typeof(Object).IsAssignableFrom(x)).ToList();
            
            if (_generateTypeAqNameMap == null || _generateTypeAqNameMap.Count != runtimeTypes.Count)
            {
                if (_generateTypeAqNameMap == null)
                {
                    _generateTypeAqNameMap = new Dictionary<string, bool>();
                }
                
                foreach (var runtimeType in runtimeTypes)
                {
                    if (runtimeType.AssemblyQualifiedName == null)
                    {
                        Debug.LogError(runtimeType);
                        continue;
                    }
                    
                    if (_generateTypeAqNameMap.ContainsKey(runtimeType.AssemblyQualifiedName))
                    {
                        continue;
                    }
                    _generateTypeAqNameMap.Add(runtimeType.AssemblyQualifiedName, true);
                }
            }

            if (_generateTypeMap == null)
            {
                bool exitMissing = false;
                
                _generateTypeMap = _generateTypeAqNameMap.Where(x =>
                {
                    if (Type.GetType(x.Key) != null)
                    {
                        return true;
                    }
                    
                    Debug.LogWarning($"Missing Type '{x.Key}'");

                    exitMissing = true;
                    
                    return false;
                }).ToDictionary(x => Type.GetType(x.Key), x => x.Value);

                if (exitMissing)
                {
                    _save();
                }
                
                _assemblyGroup = _generateTypeMap.GroupBy(x => x.Key.Assembly.FullName);
                _groupStates = new List<bool>();

                foreach (var unused in _assemblyGroup)
                {
                    _groupStates.Add(false);
                }
            }
        }

        private void OnEnable()
        {
            _loadTemple();
            
            if (_generateTypeMap == null)
            {
                _init();
            }
        }

        private static string _getKey(string key)
        {
            return $"{nameof(SerializableTypeCodeGenerate)}.{key}";
        }

        private bool _force = false;

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.SelectableLabel(GenerateSavePath,"TextField");
                if (GUILayout.Button("Select Generate Path",GUILayout.Width(150),GUILayout.Height(25)))
                {
                    var path = EditorUtility.OpenFolderPanel("Generate Save Path",
                        string.IsNullOrWhiteSpace(GenerateSavePath) ? Application.dataPath : GenerateSavePath, "");

                    if (!string.IsNullOrEmpty(path))
                    {
                        GenerateSavePath = path;
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

            NameSpace = EditorGUILayout.DelayedTextField("Name Space:", NameSpace);

            _force = EditorGUILayout.ToggleLeft("Force",_force);
            
            _drawGenerate();
        }
        
        private void _drawGenerate()
        {
            _drawAssemblyEnableOrClose();

            if (GUILayout.Button("Generate"))
            {
                if (!Directory.Exists(GenerateSavePath))
                {
                    Directory.CreateDirectory(GenerateSavePath);
                }
                
                EditorUtility.DisplayProgressBar("Generate ing", string.Empty, 0);

                var count = _generateTypeMap.Count;
                
                int i = 0;
                
                foreach (var item in _generateTypeMap)
                {
                    var runtimeType = item.Key;
                    EditorUtility.DisplayProgressBar("Generate ing", runtimeType.FullName, i / (float) count);
                    var typeName = runtimeType.Name.Split('.').Last();
                    var fileName = $"{typeName}ValueNode.cs";
                    var path = Path.Combine(GenerateSavePath, fileName);
                    
                    if (!item.Value)
                    {
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        ++i;
                        continue;
                    }
                    
                    if (_isSerializableType(runtimeType))
                    {
                        if (!_force)
                        {
                            if (File.Exists(path))
                            {
                                continue;
                            }
                        }

                        var assemblyPath = runtimeType.ConversionTypeAssemblyName();
                        
                        assemblyPath = assemblyPath.Replace(".", "/");

                        if (assemblyPath.EndsWith("/"))
                        {
                            assemblyPath = assemblyPath.Remove(assemblyPath.Length - 1, 1);
                        }
                        
                        var content = _templateContent.Replace(TypeMark, runtimeType.FullName);
                        content = content.Replace(NameSpaceMark, NameSpace);
                        content = content.Replace(IsChangeMark, "false");
                        content = content.Replace(NameMark, typeName);
                        content = content.Replace(AssemblyMark, assemblyPath);

                        File.WriteAllText(path, content);
                    }

                    ++i;
                }

                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();
            }
        }

        private bool _showAssemblyEnableOrClose;
        private bool _temp;
        private Vector2 _showAssemblyEnableOrClosePos;
        private void _drawAssemblyEnableOrClose()
        {
            _showAssemblyEnableOrClose = EditorGUILayout.Foldout(_showAssemblyEnableOrClose, "Assembly Generate Enable Or Close",true);

            if (!_showAssemblyEnableOrClose)
            {
                return;
            }
            _assemblyGroup = _generateTypeMap.GroupBy(x => x.Key.Assembly.GetName().Name);
            EditorGUI.indentLevel++;
            _showAssemblyEnableOrClosePos = EditorGUILayout.BeginScrollView(_showAssemblyEnableOrClosePos);
            {
                int index = 0;
                foreach (var grouping in _assemblyGroup)
                {
                    var list = grouping.ToList();
                    
                    EditorGUILayout.BeginHorizontal();
                    {
                        _groupStates[index] = EditorGUILayout.Foldout(_groupStates[index], grouping.Key, true);

                        var t = list.All(x => x.Value);
                        var f = list.All(x => x.Value == false);

                        if (!t && !f)
                        {
                            EditorGUI.showMixedValue = true;
                        }
                        else
                        {
                            _temp = t;
                        }
                        
                        EditorGUI.BeginChangeCheck();
                        {
                            _temp = EditorGUILayout.Toggle(_temp);
                        }
                        if (EditorGUI.EndChangeCheck())
                        {
                            foreach (var item in list)
                            {
                                _generateTypeMap[item.Key] = _temp;
                            }

                            _save();
                        }
                        
                        EditorGUI.showMixedValue = false;
                    }
                    EditorGUILayout.EndHorizontal();
                    if (_groupStates[index])
                    {
                        EditorGUI.indentLevel++;
                        {
                            foreach (var item in list)
                            {
                                EditorGUI.BeginChangeCheck();
                                {
                                    _temp = EditorGUILayout.ToggleLeft(item.Key.FullName, item.Value);
                                }
                                if (EditorGUI.EndChangeCheck())
                                {
                                    _generateTypeMap[item.Key] = _temp;
                                    _save();
                                }
                            }
                        }
                        EditorGUI.indentLevel--;
                    }
                    index ++;
                }
            }
            EditorGUILayout.EndScrollView();
            EditorGUI.indentLevel--;
        }

        static void _save()
        {
            var aqNameMap = _generateTypeMap.ToDictionary(x => x.Key.AssemblyQualifiedName, x => x.Value);
            EditorPrefs.SetString(_getKey(nameof(_generateTypeAqNameMap)),SerializationUtil.ToString(aqNameMap));
        }
        
        bool _isSerializableType(Type type)
        {
            return true;
        }
    }
}