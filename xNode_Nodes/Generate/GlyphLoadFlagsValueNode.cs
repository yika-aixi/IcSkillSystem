using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/GlyphLoadFlags Value")]
    public partial class GlyphLoadFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.LowLevel.GlyphLoadFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.LowLevel.GlyphLoadFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}