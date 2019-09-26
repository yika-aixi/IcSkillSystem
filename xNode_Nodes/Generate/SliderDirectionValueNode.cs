using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/SliderDirection Value")]
    public partial class SliderDirectionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.SliderDirection _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.SliderDirection);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}