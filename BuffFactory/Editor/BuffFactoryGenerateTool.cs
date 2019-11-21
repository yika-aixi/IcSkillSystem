using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEditorInternal;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.BuffFactory.Tool
{
    public class BuffFactoryGenerateTool : UnityEditor.EditorWindow
    {
        [UnityEditor.MenuItem("Icarus/Skill System/Buff Factory Generate Tool")]
        private static void ShowWindow()
        {
            var window = GetWindow<BuffFactoryGenerateTool>();
            window.titleContent = new UnityEngine.GUIContent("Buff Factory Generate Tool");
            window.Show();
        }
        
        private string[] _codeLines;

        private List<string> _usings;

        private List<string> _switchs;

        private string _savePath;
        
        private void OnEnable()
        {
            var location = AssetDatabase.LoadAssetAtPath<TextAsset>("BuffFactoryGenerateLocation");
            _savePath = AssetDatabase.GetAssetPath(location);

            if (!string.IsNullOrWhiteSpace(_savePath))
            {
                _savePath = Path.GetDirectoryName(_savePath);
            }
            
            var assembly = CompilationPipeline.GetAssemblies(AssembliesType.Player);
//            importer.
        }

        private void OnGUI()
        {
        }
    }
}