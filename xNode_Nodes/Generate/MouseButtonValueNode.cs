using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/MouseButton Value")]
    public partial class MouseButtonValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.MouseButton _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.MouseButton);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}