using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Repeater")]
    public class RepeaterNode:ADecoratorNode<Repeater>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        [PortTooltip("-1 infinitly loop")]
        private int _loopCount = -1;

        protected override Repeater GetDecoratorNode()
        {
            return new Repeater(GetInputValue(nameof(_loopCount),_loopCount), DecorateeNode);
        }
    }
}