using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/CooldownNode Value")]
    public partial class CooldownNodeValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.CooldownNode _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.CooldownNode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}