using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/HoldCanceledEventArgs Value")]
    public partial class HoldCanceledEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.HoldCanceledEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.HoldCanceledEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}