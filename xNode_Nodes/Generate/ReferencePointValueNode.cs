using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/ReferencePoint Value")]
    public partial class ReferencePointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.ReferencePoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.ReferencePoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}