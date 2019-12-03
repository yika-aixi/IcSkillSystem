//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月20日-00:17
//Assembly-CSharp-Editor

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor
{
    [CustomNodeEditor(typeof(UseSkillNodeNodeAction))]
    public abstract class AUseSkillNodeEditor:AQNameSelectEditor<AUseSkillNode,NPBehave.Action>
    {
        protected override Type GetBaseType()
        {
            return typeof(ISkillDataComponent);
        }

        protected override string GetAQNamePropertyName()
        {
            return "_skillComponentAQName";
        }

        protected override IEnumerable<NodePort> GetDynamicPort()
        {
            return TNode.DynamicInputs;
        }

        protected override void Init()
        {
            base.Init();
            
            UpdateDynamicPort();
        }

        protected override void DrawBody()
        {
            DrawSelectPop(new GUIContent("Skill: "));

            base.DrawBody();
        }

    }

    [CustomNodeEditor(typeof(UseSkillNodeNodeAction))]
    public class UseSkillNodeNodeActionEditor : AUseSkillNodeEditor
    {
    }
}