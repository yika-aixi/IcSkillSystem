using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCollisionQuality Value")]
    public partial class ParticleSystemCollisionQualityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCollisionQuality _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCollisionQuality);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}