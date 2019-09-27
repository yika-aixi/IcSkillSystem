using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CalendarUnit Value")]
    public partial class CalendarUnitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.iOS.CalendarUnit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.iOS.CalendarUnit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}