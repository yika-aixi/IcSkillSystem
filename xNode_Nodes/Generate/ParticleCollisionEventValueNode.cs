using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleCollisionEvent Value")]
    public partial class ParticleCollisionEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleCollisionEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleCollisionEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}