using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureHoldEvent Value")]
    public partial class GestureHoldEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureHoldEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureHoldEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}