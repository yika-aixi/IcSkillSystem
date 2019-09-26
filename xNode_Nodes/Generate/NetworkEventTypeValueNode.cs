using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UNETModule/NetworkEventType Value")]
    public partial class NetworkEventTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Networking.NetworkEventType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Networking.NetworkEventType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}