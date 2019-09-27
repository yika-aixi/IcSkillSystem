using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/VerticalWrapMode Value")]
    public partial class VerticalWrapModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.VerticalWrapMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.VerticalWrapMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}