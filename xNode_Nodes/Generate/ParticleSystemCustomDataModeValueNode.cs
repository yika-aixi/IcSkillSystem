using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCustomDataMode Value")]
    public partial class ParticleSystemCustomDataModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCustomDataMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCustomDataMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}