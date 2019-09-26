using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightProbeProxyVolume Value")]
    public partial class LightProbeProxyVolumeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightProbeProxyVolume _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightProbeProxyVolume);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}