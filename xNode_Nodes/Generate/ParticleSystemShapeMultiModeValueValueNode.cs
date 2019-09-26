using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemShapeMultiModeValue Value")]
    public partial class ParticleSystemShapeMultiModeValueValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemShapeMultiModeValue _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemShapeMultiModeValue);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}