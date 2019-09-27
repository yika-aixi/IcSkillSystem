using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemSubEmitterProperties Value")]
    public partial class ParticleSystemSubEmitterPropertiesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemSubEmitterProperties _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemSubEmitterProperties);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}