using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/EventTrigger Value")]
    public partial class EventTriggerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.EventTrigger _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.EventTrigger);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}