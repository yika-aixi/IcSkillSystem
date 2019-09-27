using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/EventHandle Value")]
    public partial class EventHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.EventHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.EventHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}