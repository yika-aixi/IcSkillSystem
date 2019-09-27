using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemTriggerEventType Value")]
    public partial class ParticleSystemTriggerEventTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemTriggerEventType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemTriggerEventType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}