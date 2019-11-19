using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Failer")]
    public class FailerNode:ADecoratorNode<Failer>
    {
        protected override Failer GetDecoratorNode()
        {
            return new Failer(DecorateeNode);
        }
    }
}