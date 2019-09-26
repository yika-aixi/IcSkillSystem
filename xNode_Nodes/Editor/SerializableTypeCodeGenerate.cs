
using System;
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
        
        [InitializeOnLoadMethod]
        static void Init()
        {
            _loadTemple();
        }

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

        [MenuItem("Cabin Icarus/IcSkillSystem/ValueNode Code Generate")]
        static void _open()
        {
            EditorWindow.CreateWindow<SerializableTypeCodeGenerate>();
        }

        private static string _getKey(string key)
        {
            return $"{nameof(SerializableTypeCodeGenerate)}.{key}";
;        }

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

            if (GUILayout.Button("Generate"))
            {
                EditorUtility.DisplayProgressBar("Generate ing",string.Empty,0);
                var runtimeTypes = TypeUtil.RuntimeTypes
                    .Where(x=>!x.IsInterface && !x.IsAbstract)
                    .Where(x=>x.IsSerializable && !x.IsGenericType)
                    .Where(x=>x.IsVisible)
                    .Where(x=>!x.IsNestedAssembly)
                    .Where(x=>!x.Assembly.GetName().FullName.Contains("NUnit"))
                    .Where(x=>!x.Assembly.GetName().FullName.Contains("Mono"))
                    .Where(x=>!x.Assembly.GetName().FullName.Contains("Cecil"))
                    .Where(x=>!x.Assembly.GetName().FullName.Contains("Test"))
                    .Where(x=>!x.Assembly.FullName.Contains("System.Reflection"));
                var count = runtimeTypes.Count();
                int i = 0;
                foreach (var runtimeType in runtimeTypes)
                {
                    if (runtimeType.GetCustomAttributes(typeof(ObsoleteAttribute),false).Length > 0)
                    {
                        continue;
                    }
                    
                    EditorUtility.DisplayProgressBar("Generate ing",runtimeType.FullName,i/(float) count);
                    if (_isSerializableType(runtimeType))
                    {
                        var content = _templateContent.Replace(TypeMark, runtimeType.FullName);
                        content = content.Replace(NameSpaceMark, NameSpace);
                        content = content.Replace(IsChangeMark, "false");
                        var typeName = runtimeType.Name.Split('.').Last();
                        content = content.Replace(NameMark, typeName);
                        if (!Directory.Exists(GenerateSavePath))
                        {
                            Directory.CreateDirectory(GenerateSavePath);
                        }
                        var path = Path.Combine(GenerateSavePath, $"{typeName}{ValueNodeTemplateName}");
                        
                        File.WriteAllText(path,content);
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