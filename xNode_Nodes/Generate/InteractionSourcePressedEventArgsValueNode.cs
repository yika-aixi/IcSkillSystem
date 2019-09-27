using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSourcePressedEventArgs Value")]
    public partial class InteractionSourcePressedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSourcePressedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSourcePressedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}