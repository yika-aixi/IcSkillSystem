using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Succeeder")]
    public class SucceederNode:ADecoratorNode
    {
        protected override void CreateNode()
        {
            base.CreateNode();

            Node = new Succeeder(DecorateeNode.Node);
        }
    }
}