using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemStopBehavior Value")]
    public partial class ParticleSystemStopBehaviorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemStopBehavior _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemStopBehavior);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}