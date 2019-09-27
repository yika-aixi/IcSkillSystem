using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/EventDispatcherGate Value")]
    public partial class EventDispatcherGateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.EventDispatcherGate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.EventDispatcherGate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}