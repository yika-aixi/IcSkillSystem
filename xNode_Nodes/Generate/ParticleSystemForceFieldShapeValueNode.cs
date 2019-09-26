using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemForceFieldShape Value")]
    public partial class ParticleSystemForceFieldShapeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemForceFieldShape _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemForceFieldShape);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}