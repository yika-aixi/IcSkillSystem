using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/NodeID Value")]
    public partial class NodeIDValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.Types.NodeID _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.Types.NodeID);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}