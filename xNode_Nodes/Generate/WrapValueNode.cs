using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Wrap Value")]
    public partial class WrapValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Wrap _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Wrap);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}