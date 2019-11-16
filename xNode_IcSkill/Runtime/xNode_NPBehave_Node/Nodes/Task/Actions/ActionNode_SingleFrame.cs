using System;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Single Frame")]
    public class ActionNode_SingleFrame : AActionNode<Func<bool>>
    {
        protected override Action GetActionNode()
        {
            return new Action(Action);
        }
    }
}