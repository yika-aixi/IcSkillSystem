using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Nodes.SkillSystems.Buff;
using UnityEngine;
using XNode;
using XNodeEditor;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    public abstract class ABuffNodeEditor:AQNameSelectEditor<ABuffNode,Node>
    {
        protected override Type GetBaseType()
        {
            return typeof(IBuffDataComponent);
        }
        
        protected override string GetAQNamePropertyName()
        {
            return "_buffAQName";
        }
        
        protected override void OnInit()
        {
            base.OnInit();
            UpdateDynamicPort();
        }
        
        protected override void DrawBody()
        {
            DrawSelectPop(new GUIContent("Buff: "));

            base.DrawBody();
        }
        
        protected override IEnumerable<NodePort> GetDynamicPort()
        {
            return TNode.DynamicInputs;
        }
    }
    
    [NodeEditor.CustomNodeEditorAttribute(typeof(AddOrRemoveBuffNode))]
    public class AddOrRemoveBuffNodeEditor:ABuffNodeEditor
    {
    }
    
    [NodeEditor.CustomNodeEditorAttribute(typeof(HasBuffConditionNode))]
    public class HasBuffNodeNodeEditor:ABuffNodeEditor
    {
    }
}