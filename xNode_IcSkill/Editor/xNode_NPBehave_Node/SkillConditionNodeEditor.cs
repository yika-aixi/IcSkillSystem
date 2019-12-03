using System;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(SkillConditionNode))]
    public class SkillConditionNodeEditor:AQNameSelectEditor<SkillConditionNode,Func<bool>>
    {
        protected override Type GetBaseType()
        {
            return typeof(ACondition);
        }

        protected override void Init()
        {
            base.Init();
            UpdateDynamicPort();
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