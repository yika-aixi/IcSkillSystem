using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/NPBehave/Get Action Value")]
    public class GetActionTaskActionNode:ValueNode<Action>
    {
        [Input(ShowBackingValue.Always,ConnectionType.Multiple,TypeConstraint.Strict)]
        private NPBehave.Action _action;

        protected override Action GetTValue()
        {
            var action = GetInputValue(nameof(_action), _action);

            return action?.GetAction;
        }
    }
}