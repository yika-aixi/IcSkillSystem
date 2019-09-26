using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/TextAlignment Value")]
    public partial class TextAlignmentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextAlignment _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextAlignment);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}