using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleFont Value")]
    public partial class StyleFontValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleFont _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleFont);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}