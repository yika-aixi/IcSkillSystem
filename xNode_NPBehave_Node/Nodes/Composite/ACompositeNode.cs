//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月21日-23:01
//Assembly-CSharp

using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Utils;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Composite
{
    public abstract class ACompositeNode:ANPBehaveNode
    {
        [SerializeField,Input(typeConstraint = TypeConstraint.Inherited)]
        [PortTooltip("节点,可多个")]
        private ANPBehaveNode _nodes;

        [SerializeField,Output()]
        private ACompositeNode _output;
        
        protected sealed override void CreateNode()
        {
            _output = this;
            
            var nodes = GetInputValue(nameof(_nodes), _nodes);
            
            if (nodes == null) 
                return;
            
            List<Node> inputNodes = new List<Node>();
            this.ToNPBehaveNodes(inputNodes);
            Node = GetNode(inputNodes);
        }

        protected abstract Node GetNode(List<Node> inputNodes);
    }
}