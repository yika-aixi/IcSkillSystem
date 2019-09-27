using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/TimerState Value")]
    public partial class TimerStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.TimerState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.TimerState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}