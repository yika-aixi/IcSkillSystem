using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleLength Value")]
    public partial class StyleLengthValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleLength _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleLength);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}