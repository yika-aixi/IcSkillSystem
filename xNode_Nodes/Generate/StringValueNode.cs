using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/String Value")]
    public partial class StringValueNode:ValueNode
    {
        [SerializeField]
        private System.String _value;

        public override Type ValueType { get; } = typeof(System.String);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}