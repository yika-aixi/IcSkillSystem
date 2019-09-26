using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCollisionType Value")]
    public partial class ParticleSystemCollisionTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCollisionType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCollisionType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}