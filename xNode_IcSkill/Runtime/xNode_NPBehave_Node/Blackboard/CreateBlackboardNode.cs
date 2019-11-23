using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Create")]
    public class CreateBlackboardNode:BlackboardNode
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        protected Clock Clock;

        private Blackboard _black;
        
        protected override Blackboard GetOutValue()
        {
            var clock = GetInputValue(nameof(Clock), Clock);

            if (clock != null)
                // 每个node 之应该创建一个
                if (_black == null)
                    _black = new Blackboard(clock);

            return _black;
        }
    }
}