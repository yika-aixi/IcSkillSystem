using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Repeater")]
    public class RepeaterNode:ADecoratorNode<Repeater>
    {
        [SerializeField]
        private int _loopCount;

        protected override Repeater GetDecoratorNode()
        {
            return new Repeater(_loopCount, DecorateeNode);
        }
    }
}