using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/LayoutElement Value")]
    public partial class LayoutElementValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.LayoutElement _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.LayoutElement);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}