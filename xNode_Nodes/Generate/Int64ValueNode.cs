using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Int64 Value")]
    public partial class Int64ValueNode:ValueNode
    {
        [SerializeField]
        private System.Int64 _value;

        public override Type ValueType { get; } = typeof(System.Int64);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}