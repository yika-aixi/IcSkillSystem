using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Overflow Value")]
    public partial class OverflowValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Overflow _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Overflow);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}