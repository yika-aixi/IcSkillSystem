using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/TrackingOriginMode Value")]
    public partial class TrackingOriginModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.TrackingOriginMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.TrackingOriginMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}