using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCustomData Value")]
    public partial class ParticleSystemCustomDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCustomData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCustomData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}