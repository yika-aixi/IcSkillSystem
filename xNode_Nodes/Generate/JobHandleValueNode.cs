using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/JobHandle Value")]
    public partial class JobHandleValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Jobs.JobHandle _value;

        public override Type ValueType { get; } = typeof(Unity.Jobs.JobHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}