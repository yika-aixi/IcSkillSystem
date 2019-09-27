using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemSortMode Value")]
    public partial class ParticleSystemSortModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemSortMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemSortMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}