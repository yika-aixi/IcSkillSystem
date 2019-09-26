using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CalendarIdentifier Value")]
    public partial class CalendarIdentifierValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.iOS.CalendarIdentifier _value;

        public override Type ValueType { get; } = typeof(UnityEngine.iOS.CalendarIdentifier);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}