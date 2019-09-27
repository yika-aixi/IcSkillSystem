using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/HostPriority Value")]
    public partial class HostPriorityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.Types.HostPriority _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.Types.HostPriority);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}