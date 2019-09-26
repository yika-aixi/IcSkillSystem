using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureTappedValidFields Value")]
    public partial class GestureTappedValidFieldsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureTappedValidFields _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureTappedValidFields);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}