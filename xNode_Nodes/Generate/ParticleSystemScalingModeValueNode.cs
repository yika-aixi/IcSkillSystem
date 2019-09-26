using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemScalingMode Value")]
    public partial class ParticleSystemScalingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemScalingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemScalingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}