using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Create")]
    public class CreateBlackboardNode:BlackboardNode
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        protected Clock Clock;

        protected override Blackboard GetOutValue()
        {
            var clock = GetInputValue(nameof(Clock), Clock);

            if (clock != null) 
                return new Blackboard(clock);

            return null;
        }
    }
}