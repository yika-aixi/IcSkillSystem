using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Align Value")]
    public partial class AlignValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Align _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Align);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}