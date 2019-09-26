//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月20日-00:17
//Assembly-CSharp-Editor

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems;
using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(UseSkillNodeNodeAction))]
    public abstract class AUseSkillNodeEditor<T>:AQNameSelectEditor<AUseSkillNode<T>,T> where T: Delegate
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

        protected override void OnInit()
        {
            base.OnInit();
            UpdateDynamicPort();
        }

        protected override void DrawBody()
        {
            DrawSelectPop(new GUIContent("Skill: "));

            base.DrawBody();
        }

    }


    [NodeEditor.CustomNodeEditorAttribute(typeof(UseSkillNodeNodeAction))]
    public class UseSkillNodeNodeActionEditor : AUseSkillNodeEditor<Action>
    {
    }
    
    [NodeEditor.CustomNodeEditorAttribute(typeof(UseSkillNodeNodeSingleFrame))]
    public class UseSkillNodeNodeSingleFrameEditor : AUseSkillNodeEditor<Func<bool>>
    {
    }
}