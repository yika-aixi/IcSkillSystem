using System;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Multi Frame bool arg")]
    public class ActionNode_MultiFrameBoolArg:AActionNode<Func<bool,Action.Result>>
    {
        protected override Action GetActionNode()
        {
            return new Action(Action);
        }
    }
}