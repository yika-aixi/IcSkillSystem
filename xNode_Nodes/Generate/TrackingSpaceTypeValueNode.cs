using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/TrackingSpaceType Value")]
    public partial class TrackingSpaceTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.TrackingSpaceType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.TrackingSpaceType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}