
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor.Utils;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEditor;
using UnityEngine;

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

        const string ValueNodeValueTypeTemplateName = "ValueNodeValueTypeTemplate.cs";
        
        const string IcVariableTemplateTemplateName = "IcVariableTemplate.cs";
        
        private static string _templateContent;

        private static string _valueTypeTemplateContent;
        private static string _icVariableTemplateContent;
        
        private static Dictionary<string,bool> _generateTypeAqNameMap;
        private static Dictionary<Type,bool> _generateTypeMap;
        private static List<bool> _groupStates;
        private static IEnumerable<IGrouping<string, KeyValuePair<Type, bool>>> _assemblyGroup;
        
        private static string _loadTemple(string name)
        {
            var guids = AssetDatabase.FindAssets(name);

            if (guids.Length == 0)
            {
                return string.Empty;
            }

            var path = AssetDatabase.GUIDToAssetPath(guids[0]);

            var textAssets = AssetDatabase.LoadAssetAtPath<TextAsset>(path);

            var content = textAssets.text;
            
            Resources.UnloadAsset(textAssets);

            return content;
        }

        private static string GenerateSavePath
        {
            get => EditorUserSettings.GetConfigValue(_getKey(nameof(GenerateSavePath)));
            set => EditorUserSettings.SetConfigValue(_getKey(nameof(GenerateSavePath)),value);
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

            var runtimeTypes = TypeUtil.GetRuntimeFilterTypes.ToList();
            bool isSave = false;
            if (_generateTypeAqNameMap == null || _generateTypeAqNameMap.Count != runtimeTypes.Count)
            {
                if (_generateTypeAqNameMap == null)
                {
                    _generateTypeAqNameMap = new Dictionary<string, bool>();
                }
                
                //add
                foreach (var runtimeType in runtimeTypes)
                {
                    if (runtimeType.AssemblyQualifiedName == null)
                    {
                        continue;
                    }
                    
                    if (_generateTypeAqNameMap.ContainsKey(runtimeType.AssemblyQualifiedName))
                    {
                        continue;
                    }
                    _generateTypeAqNameMap.Add(runtimeType.AssemblyQualifiedName, true);
                }
                
                //remove
                foreach (var typeName in _generateTypeAqNameMap.Keys.ToList())
                {
                    if (!runtimeTypes.Exists(x=>x.AssemblyQualifiedName == typeName))
                    {
                        _generateTypeAqNameMap.Remove(typeName);
                    }
                }

                isSave = true;
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

            if (isSave)
            {
                _save();
            }
        }

        private void OnEnable()
        {
            _templateContent = _loadTemple(ValueNodeTemplateName);
            
            _valueTypeTemplateContent = _loadTemple(ValueNodeValueTypeTemplateName);

            _icVariableTemplateContent = _loadTemple(IcVariableTemplateTemplateName);
            
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
        private bool _clearGenerateCode;
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
            //_clearGenerateCode = EditorGUILayout.ToggleLeft("Clear folder Before Generate",_clearGenerateCode);
            _drawGenerate();
        }

        private List<string> _nodeCSFileNames = new List<string>();
        private List<string> _icVariableCSFileNames = new List<string>();
        
        private List<string> _nodeClassNames = new List<string>();
        private List<string> _icVariableClassNames = new List<string>();
        
        private void _drawGenerate()
        {
            _drawAssemblyEnableOrClose();
            
            _nodeCSFileNames.Clear();
            _icVariableCSFileNames.Clear();
            
            _nodeClassNames.Clear();
            _icVariableClassNames.Clear();
            
            if (GUILayout.Button("Generate"))
            {
                EditorUtility.DisplayProgressBar("Generate ing", string.Empty, 0);

                if (_clearGenerateCode)
                {
                    //todo script dll no update Code may appear exist error
                    //                    if (Directory.Exists(GenerateSavePath))
//                    {
//                        foreach (var file in Directory.GetFiles(GenerateSavePath, "*.cs", SearchOption.AllDirectories))
//                        {
//                            File.Delete(file);
//                        }
//                    }
                }
                
                var count = _generateTypeMap.Count;
                
                int i = 0;
                
                foreach (var item in _generateTypeMap)
                {
                    var runtimeType = item.Key;
                    EditorUtility.DisplayProgressBar("Generate ing", runtimeType.FullName, i / (float) count);
                    var typeName = runtimeType.Name.Split('.').Last();
                    typeName = _pathInvalidRe(typeName);
                    typeName = typeName.Replace('+', '.');
                    var namespaceRe = runtimeType.Namespace;
                    namespaceRe = _pathInvalidRe(namespaceRe);

                    var fileName = $"{typeName}ValueNode.cs";

                    fileName = _getNewName(fileName, runtimeType,_nodeCSFileNames) + ".cs";
                    
                    var dir = Path.Combine(GenerateSavePath, $"{namespaceRe}");
                    
                    dir = dir.Replace('+','_');
                    
                    string path = "";
                    
                    path = Path.Combine(dir, fileName);
           
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
                        var assemblyPath = runtimeType.ConversionTypeAssemblyName();
                        assemblyPath = assemblyPath.Replace(".", "/");

                        if (assemblyPath.EndsWith("/"))
                        {
                            assemblyPath = assemblyPath.Remove(assemblyPath.Length - 1, 1);
                        }
                        
                        string content;
                        
                        string className = _getNewName(typeName,runtimeType,_nodeClassNames);
                        
                        if (!_force)
                        {
                            if (File.Exists(path))
                            {
                                goto IcVariable;
                            }
                        }

                        if (runtimeType.IsValueType)
                        {
                            content = _valueTypeTemplateContent;
                        } 
                        else
                        {
                            content = _templateContent;
                        }

                        content = _replaceContent(content, runtimeType, className, assemblyPath);

                        _writeFile(dir, path, content);

                        IcVariable:
                        _nodeCSFileNames.Add(Path.GetFileNameWithoutExtension(fileName));
                        _nodeClassNames.Add(className);
                        
                        //IcVariable
                        {
                            if (runtimeType.IsSubclassOf(typeof(ValueInfo<>)))
                            {
                                goto End;
                            }

                            dir = Path.Combine(GenerateSavePath, "IcVariables");
                            dir = Path.Combine(dir, $"{namespaceRe}");

                            fileName = $"IcVariable{typeName}.cs";
                            fileName = _getNewName(fileName, runtimeType, _icVariableCSFileNames) + ".cs";

                            path = Path.Combine(dir, fileName);
                            
                            if (!_force)
                            {
                                if (File.Exists(path))
                                {
                                    goto End;
                                }
                            }

                            className = _getNewName(typeName,runtimeType,_icVariableClassNames);
                            content = _replaceContent(_icVariableTemplateContent, runtimeType, className, assemblyPath);
                            _writeFile(dir, path, content);
                        }
                        
                        End: ;
                        _icVariableCSFileNames.Add(Path.GetFileNameWithoutExtension(fileName));
                        _icVariableClassNames.Add(className);
                    }

                    ++i;
                }
                
                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();
                _clearNullFolder();
            }
        }

        private void _clearNullFolder()
        {
            var folders = Directory.GetDirectories(GenerateSavePath);

            foreach (var folder in folders)
            {
                var files = Directory.GetFiles(folder);

                if (files.Length == 0)
                {
                    Directory.Delete(folder);   
                }
            }
        }

        private string _getNewName(string fileName, Type runtimeType,List<string> names)
        {
            if (names == null)
            {
                return fileName;
            }

            fileName = Path.GetFileNameWithoutExtension(fileName);

            int index = 0;
            int count = 1;
            var space = runtimeType.Namespace;
            var spaces = space?.Split('.');
            
            while (true)
            {
                if (!names.Contains(fileName))
                {
                    return fileName;
                }

                if (spaces == null || index >= spaces.Length - 1)
                {
                    fileName += $"_{count++}";
                }
                else
                {
                    fileName += $"_{spaces[index++]}";
                }
            }
        }

        private string _pathInvalidRe(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                foreach (var pathChar in Path.GetInvalidPathChars())
                {
                    path = path.Replace(pathChar, '_');
                }

                path = path?.Replace(".", "/");
            }

            return path;
        }

        private void _writeFile(string dir, string path, string content)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(path, content);
        }

        private string _replaceContent(string content, Type runtimeType, string typeName, string assemblyPath)
        {
            content = content.Replace(TypeMark, runtimeType.FullName.Replace('+', '.'));
            content = content.Replace(NameSpaceMark, NameSpace);
            content = content.Replace(IsChangeMark, "false");
            content = content.Replace(NameMark, typeName);
            content = content.Replace((string) AssemblyMark, assemblyPath);
            return content;
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
                                    _generateTypeMap[item.Key] = EditorGUILayout.ToggleLeft(item.Key.FullName, item.Value);
                                }
                                if (EditorGUI.EndChangeCheck())
                                {
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