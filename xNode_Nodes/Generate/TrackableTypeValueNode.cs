using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/TrackableType Value")]
    public partial class TrackableTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.TrackableType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.TrackableType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}