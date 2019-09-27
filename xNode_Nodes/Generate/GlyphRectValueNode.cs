using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/GlyphRect Value")]
    public partial class GlyphRectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.GlyphRect _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.GlyphRect);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}