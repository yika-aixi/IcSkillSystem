using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/DisplayStyle Value")]
    public partial class DisplayStyleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.DisplayStyle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.DisplayStyle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}