using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/HolographicStreamerConnectionFailureReason Value")]
    public partial class HolographicStreamerConnectionFailureReasonValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.HolographicStreamerConnectionFailureReason _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.HolographicStreamerConnectionFailureReason);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}