using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemStopAction Value")]
    public partial class ParticleSystemStopActionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemStopAction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemStopAction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}