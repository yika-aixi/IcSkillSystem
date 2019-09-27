using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/TrackableId Value")]
    public partial class TrackableIdValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.TrackableId _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.TrackableId);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}