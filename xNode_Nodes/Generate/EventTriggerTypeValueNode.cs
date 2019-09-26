using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/EventTriggerType Value")]
    public partial class EventTriggerTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.EventTriggerType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.EventTriggerType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}