using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCollisionMode Value")]
    public partial class ParticleSystemCollisionModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCollisionMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCollisionMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}