using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/GlyphRenderMode Value")]
    public partial class GlyphRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.LowLevel.GlyphRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.LowLevel.GlyphRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}