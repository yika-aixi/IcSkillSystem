using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/PositionalLocatorState Value")]
    public partial class PositionalLocatorStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.PositionalLocatorState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.PositionalLocatorState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}