using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemInheritVelocityMode Value")]
    public partial class ParticleSystemInheritVelocityModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemInheritVelocityMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemInheritVelocityMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}