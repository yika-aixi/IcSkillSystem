using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleCursor Value")]
    public partial class StyleCursorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleCursor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleCursor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}