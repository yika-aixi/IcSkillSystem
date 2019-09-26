using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystem Value")]
    public partial class ParticleSystemValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystem _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystem);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}