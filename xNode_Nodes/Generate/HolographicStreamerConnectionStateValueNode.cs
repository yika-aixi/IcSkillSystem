using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/HolographicStreamerConnectionState Value")]
    public partial class HolographicStreamerConnectionStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.HolographicStreamerConnectionState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.HolographicStreamerConnectionState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}