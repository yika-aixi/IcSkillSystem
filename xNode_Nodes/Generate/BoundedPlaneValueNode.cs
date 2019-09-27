using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/BoundedPlane Value")]
    public partial class BoundedPlaneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.BoundedPlane _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.BoundedPlane);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}