using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Boolean Value")]
    public partial class BooleanValueNode:ValueNode
    {
        [SerializeField]
        private System.Boolean _value;

        public override Type ValueType { get; } = typeof(System.Boolean);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}