using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Position Value")]
    public partial class PositionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Position _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Position);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}