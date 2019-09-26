using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/PickingMode Value")]
    public partial class PickingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.PickingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.PickingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}