using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/JobType Value")]
    public partial class JobTypeValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Jobs.LowLevel.Unsafe.JobType _value;

        public override Type ValueType { get; } = typeof(Unity.Jobs.LowLevel.Unsafe.JobType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}