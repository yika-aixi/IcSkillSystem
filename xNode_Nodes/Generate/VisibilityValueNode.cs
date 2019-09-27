using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Visibility Value")]
    public partial class VisibilityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Visibility _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Visibility);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}