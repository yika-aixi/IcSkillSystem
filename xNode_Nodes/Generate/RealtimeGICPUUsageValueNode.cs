using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RealtimeGICPUUsage Value")]
    public partial class RealtimeGICPUUsageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RealtimeGICPUUsage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RealtimeGICPUUsage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}