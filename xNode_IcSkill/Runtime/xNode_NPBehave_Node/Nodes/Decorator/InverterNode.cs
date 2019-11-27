using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
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