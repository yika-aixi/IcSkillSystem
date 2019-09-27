using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemShapeTextureChannel Value")]
    public partial class ParticleSystemShapeTextureChannelValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemShapeTextureChannel _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemShapeTextureChannel);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}