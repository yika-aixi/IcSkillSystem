using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
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