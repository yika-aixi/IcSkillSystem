using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/XNode/NodePort Value")]
    public partial class NodePortValueNode:ValueNode
    {
        [SerializeField]
        private XNode.NodePort _value;

        public override Type ValueType { get; } = typeof(XNode.NodePort);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}