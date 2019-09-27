using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/NPBehaveExampleClockThrottling Value")]
    public partial class NPBehaveExampleClockThrottlingValueNode:ValueNode
    {
        [SerializeField]
        private NPBehaveExampleClockThrottling _value;

        public override Type ValueType { get; } = typeof(NPBehaveExampleClockThrottling);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}