using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/HorizontalWrapMode Value")]
    public partial class HorizontalWrapModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HorizontalWrapMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HorizontalWrapMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}