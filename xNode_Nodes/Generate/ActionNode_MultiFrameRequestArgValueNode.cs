using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/ActionNode_MultiFrameRequestArg Value")]
    public partial class ActionNode_MultiFrameRequestArgValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.ActionNode_MultiFrameRequestArg _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks.ActionNode_MultiFrameRequestArg);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}