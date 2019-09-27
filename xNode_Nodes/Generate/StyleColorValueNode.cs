using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleColor Value")]
    public partial class StyleColorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleColor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleColor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}