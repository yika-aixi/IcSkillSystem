using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Scrollbar Value")]
    public partial class ScrollbarValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Scrollbar _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Scrollbar);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}