using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemAnimationRowMode Value")]
    public partial class ParticleSystemAnimationRowModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemAnimationRowMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemAnimationRowMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}