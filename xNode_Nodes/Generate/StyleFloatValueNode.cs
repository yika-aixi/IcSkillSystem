using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleFloat Value")]
    public partial class StyleFloatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleFloat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleFloat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}