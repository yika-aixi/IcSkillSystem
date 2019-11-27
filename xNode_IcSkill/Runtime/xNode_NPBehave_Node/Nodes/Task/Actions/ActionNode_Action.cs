using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Action")]
    public class ActionNode_Action:AActionNode<System.Action>
    {
        protected override Action GetActionNode()
        {
            return new Action(Action);
        }
    }
}