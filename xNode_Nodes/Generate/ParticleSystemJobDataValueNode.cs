using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemJobData Value")]
    public partial class ParticleSystemJobDataValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.ParticleSystemJobs.ParticleSystemJobData _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.ParticleSystemJobs.ParticleSystemJobData);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}