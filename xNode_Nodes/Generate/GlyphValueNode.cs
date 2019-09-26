using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/Glyph Value")]
    public partial class GlyphValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.Glyph _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.Glyph);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}