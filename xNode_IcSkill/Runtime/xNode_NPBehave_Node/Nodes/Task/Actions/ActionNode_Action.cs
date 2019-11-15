using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Action/Action")]
    public class ActionNode_Action:AActionNode<System.Action>
    {
        protected override Action GetActionNode()
        {
            return new Action(Action);
        }
    }
}