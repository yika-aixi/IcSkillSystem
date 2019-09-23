using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Failer")]
    public class FailerNode:ADecoratorNode
    {
        protected override void CreateNode()
        {
            base.CreateNode();
            
            Node = new Failer(DecorateeNode.Node);
        }
    }
}