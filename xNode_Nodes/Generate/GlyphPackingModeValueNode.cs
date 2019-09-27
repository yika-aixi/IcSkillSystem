using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/GlyphPackingMode Value")]
    public partial class GlyphPackingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.LowLevel.GlyphPackingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.LowLevel.GlyphPackingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}