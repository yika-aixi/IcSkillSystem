using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeUsage Value")]
    public partial class ReflectionProbeUsageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeUsage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeUsage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}