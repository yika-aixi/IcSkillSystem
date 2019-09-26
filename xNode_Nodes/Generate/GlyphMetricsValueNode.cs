using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/GlyphMetrics Value")]
    public partial class GlyphMetricsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.GlyphMetrics _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.GlyphMetrics);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}