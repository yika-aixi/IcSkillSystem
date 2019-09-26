using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Single Value")]
    public partial class SingleValueNode:ValueNode
    {
        [SerializeField]
        private System.Single _value;

        public override Type ValueType { get; } = typeof(System.Single);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}