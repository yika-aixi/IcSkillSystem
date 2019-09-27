using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightProbeUsage Value")]
    public partial class LightProbeUsageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.LightProbeUsage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.LightProbeUsage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}