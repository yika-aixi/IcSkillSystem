using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/AccelerationEvent Value")]
    public partial class AccelerationEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AccelerationEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AccelerationEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}