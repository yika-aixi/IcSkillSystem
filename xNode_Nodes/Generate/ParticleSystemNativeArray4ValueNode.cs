using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemNativeArray4 Value")]
    public partial class ParticleSystemNativeArray4ValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.ParticleSystemJobs.ParticleSystemNativeArray4 _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.ParticleSystemJobs.ParticleSystemNativeArray4);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}