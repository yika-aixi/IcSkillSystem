using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator
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