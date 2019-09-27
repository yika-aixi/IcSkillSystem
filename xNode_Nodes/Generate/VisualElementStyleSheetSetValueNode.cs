using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/VisualElementStyleSheetSet Value")]
    public partial class VisualElementStyleSheetSetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.VisualElementStyleSheetSet _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.VisualElementStyleSheetSet);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}