using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/InteractionSourceNode Value")]
    public partial class InteractionSourceNodeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.InteractionSourceNode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.InteractionSourceNode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}