using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/XRRaycastHit Value")]
    public partial class XRRaycastHitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.XRRaycastHit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.XRRaycastHit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}