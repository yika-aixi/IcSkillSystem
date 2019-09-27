using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemGameObjectFilter Value")]
    public partial class ParticleSystemGameObjectFilterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemGameObjectFilter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemGameObjectFilter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}