using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemAnimationMode Value")]
    public partial class ParticleSystemAnimationModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemAnimationMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemAnimationMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}