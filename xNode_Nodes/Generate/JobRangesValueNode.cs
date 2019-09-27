using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/JobRanges Value")]
    public partial class JobRangesValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Jobs.LowLevel.Unsafe.JobRanges _value;

        public override Type ValueType { get; } = typeof(Unity.Jobs.LowLevel.Unsafe.JobRanges);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}