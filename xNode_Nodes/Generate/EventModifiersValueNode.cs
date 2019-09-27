using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/EventModifiers Value")]
    public partial class EventModifiersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EventModifiers _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EventModifiers);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}