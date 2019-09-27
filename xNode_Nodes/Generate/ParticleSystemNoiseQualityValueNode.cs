using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemNoiseQuality Value")]
    public partial class ParticleSystemNoiseQualityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemNoiseQuality _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemNoiseQuality);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}