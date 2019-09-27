using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleKeyword Value")]
    public partial class StyleKeywordValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleKeyword _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleKeyword);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}