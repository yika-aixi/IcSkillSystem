using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSourcePressType Value")]
    public partial class InteractionSourcePressTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSourcePressType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSourcePressType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}