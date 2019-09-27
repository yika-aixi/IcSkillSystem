using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleInt Value")]
    public partial class StyleIntValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleInt _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleInt);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}