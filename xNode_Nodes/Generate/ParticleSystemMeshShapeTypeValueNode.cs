using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemMeshShapeType Value")]
    public partial class ParticleSystemMeshShapeTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemMeshShapeType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemMeshShapeType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}