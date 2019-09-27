using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/InverterNode Value")]
    public partial class InverterNodeValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.InverterNode _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.InverterNode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}