using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemNativeArray3 Value")]
    public partial class ParticleSystemNativeArray3ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.ParticleSystemJobs.ParticleSystemNativeArray3 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.ParticleSystemJobs.ParticleSystemNativeArray3);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}