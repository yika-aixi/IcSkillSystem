using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/String Value")]
    public class StringNode:ValueNode
    {
        [SerializeField,Output(ShowBackingValue.Always)]
        [PortTooltip("值出口")]
        private string _value;

        public override object Value => _value;
    }
}