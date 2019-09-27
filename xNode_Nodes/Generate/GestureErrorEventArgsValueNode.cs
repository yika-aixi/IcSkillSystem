using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/GestureErrorEventArgs Value")]
    public partial class GestureErrorEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.GestureErrorEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.GestureErrorEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}