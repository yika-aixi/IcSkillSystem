using System;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Action/Multi Frame Request arg")]
    public class ActionNode_MultiFrameRequestArg:AActionNode<Func<Action.Request,Action.Result>>
    {
        protected override Action GetActionNode()
        {
            return new Action(Action);
        }
    }
}