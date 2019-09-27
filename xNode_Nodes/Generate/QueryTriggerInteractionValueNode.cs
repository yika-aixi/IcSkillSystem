using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/QueryTriggerInteraction Value")]
    public partial class QueryTriggerInteractionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.QueryTriggerInteraction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.QueryTriggerInteraction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}