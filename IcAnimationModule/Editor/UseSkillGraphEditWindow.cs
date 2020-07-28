//Create: Icarus
//ヾ(•ω•`)o
//2020-07-28 06:27
//Assembly-CSharp

using System;
using System.Collections.Generic;
using System.IO;
using CabinIcarus.EditorFrame.Attributes;
using CabinIcarus.EditorFrame.Localization;
using CabinIcarus.EditorFrame.Utils;
using CabinIcarus.IcAnimationEditor;
using CabinIcarus.IcFrameWork.IcSkillSystem.IcAnimationModule.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.IcAnimationModule.Editor
{
#if ICANIMATIONEDITOR
    [InitializeOnRun(1)]
    public class UseSkillGraphEditWindow:ATAnimationEditorModuleBase
    {
        private static string _localizationFolderPath;

        static UseSkillGraphEditWindow()
        {
            var files = Directory.GetFiles(PathUtil.GetCombinePath(Directory.GetCurrentDirectory(),"Assets","Cabin Icarus"),"*.cs",SearchOption.AllDirectories);

            string path = string.Empty;

            foreach (var file in files)
            {
                if (file.IndexOf(nameof(UseSkillGraphEditWindow), StringComparison.Ordinal) != -1)
                {
                    path = file;
                    break;
                }
            }

            if (path != string.Empty)
            {
                var dir = Path.GetDirectoryName(path);
                _localizationFolderPath = PathUtil.GetCombinePath(dir, "Localizations");
            }
            
            EditorApplication.update += _init;
        }

        private static void _init()
        {
            EditorApplication.update -= _init;
            

            
            LocalizationManager.Instance.LoadAllLanguage(PathUtil.GetCombinePath(_localizationFolderPath ,"Static"),new CsvLocalizationCreateAndParse(), 1);
        }

        protected override void On_Enable()
        {
            base.On_Enable();

            LoadLanguageConfig(PathUtil.GetCombinePath(_localizationFolderPath,"Window"), new CsvLocalizationCreateAndParse());
        }

        public override bool DefaultOpenState { get; } = false;
        public override string Title =>  LocalizationManager.Instance.GetValue("UseSkillGraphEditWindowTitle","Use Skill Graph Edit");

        public override string Description =>
            LocalizationManager.Instance.GetValue("UseSkillGraphEditWindowDescription", "Skill Graph Editor");

        public override int Priority { get; } = 10;
        public override Type DefaultRuntime { get; } = typeof(UseSkillGraphModule);

        private IcSkillGraph _graph;
        private int _runtimeModuleIndex;
        
        readonly List<UseSkillGraphModuleData> _drawShowCurrentFrameAllAnimationClipUseSkillGraphs =
            new List<UseSkillGraphModuleData>();
        protected override void OnBodyEditor()
        {
            _graph = _drawSkillGraphSelectField(_graph);
            
            _runtimeModuleIndex = DrawRuntimeModule(_runtimeModuleIndex);
            
            if (GUILayout.Button(GetLanguageValue("AddSkillGraph")))
            {
                var data = CreateInstance<UseSkillGraphModuleData>();
                data._graph = _graph;
                data.HandleIndex = _runtimeModuleIndex;
                data.Init($"{CurrentFrame}_{_graph.name}", data.GetHashCode());

                CurrentAnimationClipInfo.AddModuleDataAndUpdateAsset(CurrentFrame,
                    CurrentTime, data);
            }
            
            DrawShowFrameAllModuleData(CurrentFrame,             GetLanguageValue("CurrentFrameAllAudioModuleData"),
                _drawShowCurrentFrameAllAnimationClipUseSkillGraphs, _drawAudioModuleData);
        }

        private IcSkillGraph _drawSkillGraphSelectField(IcSkillGraph graph)
        {
            return (IcSkillGraph) EditorGUILayout.ObjectField(GetLanguageValue("SkillGraphLabel"), graph, typeof(IcSkillGraph),
                false);
        }

        private void _drawAudioModuleData(UseSkillGraphModuleData obj)
        {
            var    moduleData = obj;
            string tooltip;
            GUI.backgroundColor = GetRuntimeModuleBackColorAndSetMessage(moduleData, out tooltip);
            EditorGUILayout.BeginHorizontal("box");
            {
                var size  = Util.GuiUtil.GetStringContentSize(moduleData.name, EditorStyles.label);
                var width = (size.x + 5);
                EditorGUILayout.LabelField(new GUIContent(moduleData.name, tooltip),
                    GUILayout.Width(width));
                EditorGUI.BeginChangeCheck();
                moduleData.UndoRecordUpdate();
                {
                    Util.GuiUtil.DrawUILine(Color.red, (int) size.y, 1);
                    moduleData._graph = _drawSkillGraphSelectField(moduleData._graph);
                    
                    Util.GuiUtil.DrawUILine(Color.red, (int) size.y, 1);
                    var result = DrawRuntimeModule(moduleData.HandleIndex);

                    moduleData.HandleIndex = result;
                }
                if (EditorGUI.EndChangeCheck())
                {
                    moduleData.UpdateAsset();
                }

                DrawDelete(moduleData);
            }
            EditorGUILayout.EndHorizontal();
        }
    }
#endif
}