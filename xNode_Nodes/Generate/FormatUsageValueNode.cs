using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FormatUsage Value")]
    public partial class FormatUsageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Rendering.FormatUsage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Rendering.FormatUsage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}