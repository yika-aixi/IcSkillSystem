using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSourceProperties Value")]
    public partial class InteractionSourcePropertiesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSourceProperties _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSourceProperties);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}