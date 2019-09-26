using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/ScrollRect Value")]
    public partial class ScrollRectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.ScrollRect _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.ScrollRect);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}