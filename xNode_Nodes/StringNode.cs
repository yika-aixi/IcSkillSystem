using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/String Value")]
    public class StringNode:ValueNode
    {
        [SerializeField]
        [PortTooltip("值出口")]
        private string _value;

        public override Type ValueType { get; set; } = typeof(string);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}