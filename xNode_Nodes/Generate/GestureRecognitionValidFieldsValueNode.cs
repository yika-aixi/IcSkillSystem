using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureRecognitionValidFields Value")]
    public partial class GestureRecognitionValidFieldsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureRecognitionValidFields _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureRecognitionValidFields);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}