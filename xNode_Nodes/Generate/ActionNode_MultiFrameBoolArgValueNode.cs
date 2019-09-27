using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/ActionNode_MultiFrameBoolArg Value")]
    public partial class ActionNode_MultiFrameBoolArgValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.ActionNode_MultiFrameBoolArg _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.ActionNode_MultiFrameBoolArg);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}