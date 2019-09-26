using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/FlexDirection Value")]
    public partial class FlexDirectionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.FlexDirection _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.FlexDirection);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}