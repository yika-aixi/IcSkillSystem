using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/TrackingState Value")]
    public partial class TrackingStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.TrackingState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.TrackingState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}