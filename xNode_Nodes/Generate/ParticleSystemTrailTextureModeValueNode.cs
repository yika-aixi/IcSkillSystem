using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemTrailTextureMode Value")]
    public partial class ParticleSystemTrailTextureModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemTrailTextureMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemTrailTextureMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}