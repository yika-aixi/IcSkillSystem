using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemSimulationSpace Value")]
    public partial class ParticleSystemSimulationSpaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemSimulationSpace _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemSimulationSpace);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}