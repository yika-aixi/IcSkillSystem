using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Justify Value")]
    public partial class JustifyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Justify _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Justify);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}