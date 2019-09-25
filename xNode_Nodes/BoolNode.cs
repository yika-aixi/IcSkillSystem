using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Bool Value")]
    public class BoolNode:ValueNode
    {
        [SerializeField]
        private bool _value;

        public override Type ValueType { get; set; } = typeof(bool);

        protected override object GetOutValue()
        {
            return _value;
        }
    }
}