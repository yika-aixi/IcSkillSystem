using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/ContextType Value")]
    public partial class ContextTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.ContextType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.ContextType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}