using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemRingBufferMode Value")]
    public partial class ParticleSystemRingBufferModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemRingBufferMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemRingBufferMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}