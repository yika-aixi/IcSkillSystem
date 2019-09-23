using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using UnityEngine;
using XNode;
using Object = UnityEngine.Object;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Object Value")]
    public class ObjectNode:ValueNode
    {
        [SerializeField,Output(ShowBackingValue.Always)]
        [PortTooltip("值出口")]
        private Object _value;

        public override object Value => _value;
    }
}