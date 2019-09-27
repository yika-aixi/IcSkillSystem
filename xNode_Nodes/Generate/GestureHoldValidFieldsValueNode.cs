using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureHoldValidFields Value")]
    public partial class GestureHoldValidFieldsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureHoldValidFields _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureHoldValidFields);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}