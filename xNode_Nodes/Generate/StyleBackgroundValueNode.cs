using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleBackground Value")]
    public partial class StyleBackgroundValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleBackground _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleBackground);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}