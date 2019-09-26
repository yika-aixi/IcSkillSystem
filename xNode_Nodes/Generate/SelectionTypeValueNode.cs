using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/SelectionType Value")]
    public partial class SelectionTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.SelectionType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.SelectionType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}