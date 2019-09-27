using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/GestureRecognitionEvent Value")]
    public partial class GestureRecognitionEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.GestureRecognitionEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.GestureRecognitionEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}