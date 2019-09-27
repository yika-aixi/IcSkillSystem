using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSource Value")]
    public partial class InteractionSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}