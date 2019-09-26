using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemOverlapAction Value")]
    public partial class ParticleSystemOverlapActionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemOverlapAction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemOverlapAction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}