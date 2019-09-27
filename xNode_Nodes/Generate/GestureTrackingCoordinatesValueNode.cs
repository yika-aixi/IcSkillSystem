using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureTrackingCoordinates Value")]
    public partial class GestureTrackingCoordinatesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureTrackingCoordinates _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureTrackingCoordinates);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}