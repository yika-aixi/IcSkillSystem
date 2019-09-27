using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemGradientMode Value")]
    public partial class ParticleSystemGradientModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemGradientMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemGradientMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}