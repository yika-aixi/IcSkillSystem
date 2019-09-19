//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月20日-00:17
//Assembly-CSharp-Editor

using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Task;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(UseSkillNode))]
    public class UseSkillNodeEditor:NodeEditor
    {
        private static List<string> _Types;
        private UseSkillNode _skillNode;

        public override void OnCreate()
        {
            _skillNode = (UseSkillNode) target;
            _skillProperty = serializedObject.FindProperty("_skillComponentAQName");
            _Types = new List<string>();

            _Types.AddRange(CabinIcarus.EditorFrame.Utils.TypeUtil.GetFilterSystemAssemblyQualifiedNames(typeof(ISkillDataComponent)));

            //todo 没有 Editor Frame 的话吧上面那行注释,使用这行即可,下面这行,没做测试 - -- 
//            _Types.AddRange(AppDomain.CurrentDomain.GetAllTypes().Where(x=> typeof(ISkillDataComponent).IsAssignableFrom(x)).Select(x=>x.AssemblyQualifiedName));

            _selectIndex = _Types.FindIndex(x=> x == _skillProperty.stringValue);
        }


        private int _selectIndex;
        private SerializedProperty _skillProperty;

        public override void OnBodyGUI()
        {
            _selectIndex = EditorGUILayout.Popup("Skill: ", _selectIndex,_Types.Select(x=>x.Split(',')[0]).ToArray());

            if (GUI.changed)
            {
                _skillProperty.stringValue = _Types[_selectIndex];
            }
            
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("_skillNode"));
        }
    }
}