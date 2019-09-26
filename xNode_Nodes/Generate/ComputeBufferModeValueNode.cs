using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ComputeBufferMode Value")]
    public partial class ComputeBufferModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ComputeBufferMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ComputeBufferMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}