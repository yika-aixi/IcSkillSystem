using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/SerializationCompletionReason Value")]
    public partial class SerializationCompletionReasonValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Sharing.SerializationCompletionReason _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Sharing.SerializationCompletionReason);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}