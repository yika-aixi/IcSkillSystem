using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/EventSystem Value")]
    public partial class EventSystemValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventSystems.EventSystem _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventSystems.EventSystem);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}