using System;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(SkillConditionNode))]
    public class SkillConditionNodeEditor:AQNameSelectEditor<SkillConditionNode,Func<bool>>
    {
        protected override Type GetBaseType()
        {
            return typeof(ACondition);
        }

        protected override void DrawBody()
        {
            DrawSelectPop(new GUIContent("Skill Condition"));
            
            base.DrawBody();
        }

        protected override string GetAQNamePropertyName()
        {
            return "_conditionAQName";
        }
    }
}