
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
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
        const string ValueNodeTemplateName = "ValueNodeTemplate.cs";

        private static string _templateContent;

        private static List<string> _generateAssemblys;
        
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
            var wind = EditorWindow.CreateWindow<SerializableTypeCodeGenerate>();
            wind.titleContent = new GUIContent("ValueNode Generate");
            _generateAssemblys = new List<string>();
            _generateAssemblys =
                JsonUtility.FromJson<List<string>>(EditorPrefs.GetString(_getKey(nameof(_generateAssemblys))));
        }

        private void OnEnable()
        {
            _loadTemple();
        }

        private static string _getKey(string key)
        {
            return $"{nameof(SerializableTypeCodeGenerate)}.{key}";
;        }

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
            if (GUILayout.Button("Generate"))
            {
                if (!Directory.Exists(GenerateSavePath))
                {
                    Directory.CreateDirectory(GenerateSavePath);
                }


                EditorUtility.DisplayProgressBar("Generate ing", string.Empty, 0);

                var runtimeTypes = TypeUtil.UnityRuntimeTypes
                    .Where(x => !typeof(Delegate).IsAssignableFrom(x))
                    .Where(x => !typeof(Exception).IsAssignableFrom(x))
                    .Where(x => x.CustomAttributes.All(y => y.AttributeType != typeof(ObsoleteAttribute)))
                    .Where(x => !typeof(Attribute).IsAssignableFrom(x))
                    .Where(x => x.IsSerializable)
                    .Where(x => !x.IsGenericType)
                    .Where(x => !x.Assembly.GlobalAssemblyCache)
                    .Where(x => !x.IsPointer)
                    .Where(x => x.IsClass || x.IsValueType || x.IsEnum)
                    .Where(x => x.IsVisible)
                    .Where(x => !x.FullName.Contains("UnityEngine.TestTools")).ToList();


                runtimeTypes.Add(typeof(int));
                runtimeTypes.Add(typeof(long));
                runtimeTypes.Add(typeof(float));
                runtimeTypes.Add(typeof(bool));
                runtimeTypes.Add(typeof(string));

                var count = runtimeTypes.Count;
                
                int i = 0;
                
                foreach (var runtimeType in runtimeTypes)
                {
                    EditorUtility.DisplayProgressBar("Generate ing", runtimeType.FullName, i / (float) count);
                    if (_isSerializableType(runtimeType))
                    {
                        var typeName = runtimeType.Name.Split('.').Last();
                        var fileName = $"{typeName}ValueNode.cs";
                        var path = Path.Combine(GenerateSavePath, fileName);

                        if (!_force)
                        {
                            if (File.Exists(path))
                            {
                                continue;
                            }
                        }

                        var content = _templateContent.Replace(TypeMark, runtimeType.FullName);
                        content = content.Replace(NameSpaceMark, NameSpace);
                        content = content.Replace(IsChangeMark, "false");
                        content = content.Replace(NameMark, typeName);

                        File.WriteAllText(path, content);
                    }

                    ++i;
                }

                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();
            }
        }

        bool _isSerializableType(Type type)
        {
            return true;
        }
    }
}