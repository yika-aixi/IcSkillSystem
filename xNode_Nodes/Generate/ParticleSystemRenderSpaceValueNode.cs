using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemRenderSpace Value")]
    public partial class ParticleSystemRenderSpaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemRenderSpace _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemRenderSpace);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}