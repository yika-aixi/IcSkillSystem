using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/HapticCapabilities Value")]
    public partial class HapticCapabilitiesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.HapticCapabilities _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.HapticCapabilities);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}