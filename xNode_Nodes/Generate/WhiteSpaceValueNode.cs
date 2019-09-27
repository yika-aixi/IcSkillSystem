using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/WhiteSpace Value")]
    public partial class WhiteSpaceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.WhiteSpace _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.WhiteSpace);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}