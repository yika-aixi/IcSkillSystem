using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/BlackboardConditionNode Value")]
    public partial class BlackboardConditionNodeValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.BlackboardConditionNode _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator.BlackboardConditionNode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}