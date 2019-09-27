using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCullingMode Value")]
    public partial class ParticleSystemCullingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCullingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCullingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}