using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ComputeBufferType Value")]
    public partial class ComputeBufferTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ComputeBufferType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ComputeBufferType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}