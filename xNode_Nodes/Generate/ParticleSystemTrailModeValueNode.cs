using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemTrailMode Value")]
    public partial class ParticleSystemTrailModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemTrailMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemTrailMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}