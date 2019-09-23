using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Inverter")]
    public class InverterNode:ADecoratorNode
    {
        protected override void CreateNode()
        {
            base.CreateNode();
            
            Node = new Inverter(DecorateeNode.Node);
        }
    }
}