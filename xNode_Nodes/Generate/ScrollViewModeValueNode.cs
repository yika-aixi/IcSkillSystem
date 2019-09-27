using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/ScrollViewMode Value")]
    public partial class ScrollViewModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.ScrollViewMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.ScrollViewMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}