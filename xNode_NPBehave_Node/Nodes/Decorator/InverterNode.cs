using NPBehave;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Inverter")]
    public class InverterNode:ADecoratorNode<Inverter>
    {
        protected override Inverter GetDecoratorNode()
        {
            return new Inverter(DecorateeNode);
        }
    }
}