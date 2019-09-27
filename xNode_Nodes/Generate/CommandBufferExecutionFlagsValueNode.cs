using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CommandBufferExecutionFlags Value")]
    public partial class CommandBufferExecutionFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CommandBufferExecutionFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CommandBufferExecutionFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}