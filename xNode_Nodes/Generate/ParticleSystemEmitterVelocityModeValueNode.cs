using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemEmitterVelocityMode Value")]
    public partial class ParticleSystemEmitterVelocityModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemEmitterVelocityMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemEmitterVelocityMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}