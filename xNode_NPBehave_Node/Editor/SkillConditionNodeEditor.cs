using System;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(SkillConditionNode))]
    public class SkillConditionNodeEditor:AQNameSelectEditor<SkillConditionNode>
    {
        private SerializedProperty _blackboardProperty;
        private SerializedProperty _outputProperty;
        
        protected override void OnInit()
        {
            base.OnInit();
            
            _blackboardProperty = serializedObject.FindProperty("_blackboardNode");
            _outputProperty = serializedObject.FindProperty(TNode.OutPutName);
        }

        protected override Type GetBaseType()
        {
            return typeof(ACondition);
        }

        protected override void DrawBody()
        {
            _baseDraw();
            
            DrawSelectPop(new GUIContent("Skill Condition"));
        }

        protected override string GetAQNamePropertyName()
        {
            return "_conditionAQName";
        }
        
        private void _baseDraw()
        {
            NodeEditorGUILayout.PropertyField(_blackboardProperty);
            NodeEditorGUILayout.PropertyField(_outputProperty);
        }
    }
}