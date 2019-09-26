using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemForceField Value")]
    public partial class ParticleSystemForceFieldValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemForceField _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemForceField);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}