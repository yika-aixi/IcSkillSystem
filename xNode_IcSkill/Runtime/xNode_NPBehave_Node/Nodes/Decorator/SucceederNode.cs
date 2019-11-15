using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Succeeder")]
    public class SucceederNode:ADecoratorNode<Succeeder>
    {
        protected override Succeeder GetDecoratorNode()
        {
            return new Succeeder(DecorateeNode);
        }
    }
}