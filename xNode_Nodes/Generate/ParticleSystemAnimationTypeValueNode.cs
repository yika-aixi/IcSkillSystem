using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemAnimationType Value")]
    public partial class ParticleSystemAnimationTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemAnimationType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemAnimationType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}