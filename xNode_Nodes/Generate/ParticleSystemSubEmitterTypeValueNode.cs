using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemSubEmitterType Value")]
    public partial class ParticleSystemSubEmitterTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemSubEmitterType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemSubEmitterType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}