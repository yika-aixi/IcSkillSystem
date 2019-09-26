using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/LengthUnit Value")]
    public partial class LengthUnitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.LengthUnit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.LengthUnit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}