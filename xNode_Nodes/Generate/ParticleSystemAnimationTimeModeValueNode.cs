using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemAnimationTimeMode Value")]
    public partial class ParticleSystemAnimationTimeModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemAnimationTimeMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemAnimationTimeMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}