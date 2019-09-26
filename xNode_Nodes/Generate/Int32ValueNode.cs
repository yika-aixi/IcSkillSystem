using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Int32 Value")]
    public partial class Int32ValueNode:ValueNode
    {
        [SerializeField]
        private System.Int32 _value;

        public override Type ValueType { get; } = typeof(System.Int32);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}