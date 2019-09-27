using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/HoldStartedEventArgs Value")]
    public partial class HoldStartedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.HoldStartedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.HoldStartedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}