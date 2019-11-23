using System;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Multi Frame Request arg")]
    public class ActionNode_MultiFrameRequestArg:AActionNode<Func<Action.Request,Action.Result>>
    {
        protected override Action GetActionNode()
        {
            return new Action(Action);
        }
    }
}