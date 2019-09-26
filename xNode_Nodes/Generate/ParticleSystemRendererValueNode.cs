using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemRenderer Value")]
    public partial class ParticleSystemRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}