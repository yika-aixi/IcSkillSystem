using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemRenderMode Value")]
    public partial class ParticleSystemRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}