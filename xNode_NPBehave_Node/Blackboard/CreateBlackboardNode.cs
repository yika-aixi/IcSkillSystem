using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Create")]
    public class CreateBlackboardNode:BlackboardNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        protected ClockNode ClockNode;

        protected override void CreateNode()
        {
            var clock = GetInputValue(nameof(ClockNode), ClockNode);

            if (clock != null) 
                Blackboard = new Blackboard(clock.Clock);
        }
    }
}