using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScheduleMode Value")]
    public partial class ScheduleModeValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Jobs.LowLevel.Unsafe.ScheduleMode _value;

        public override Type ValueType { get; } = typeof(Unity.Jobs.LowLevel.Unsafe.ScheduleMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}