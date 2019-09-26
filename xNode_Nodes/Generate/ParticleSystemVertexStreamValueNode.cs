using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemVertexStream Value")]
    public partial class ParticleSystemVertexStreamValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemVertexStream _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemVertexStream);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}