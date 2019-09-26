using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/TrickleDown Value")]
    public partial class TrickleDownValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.TrickleDown _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.TrickleDown);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}