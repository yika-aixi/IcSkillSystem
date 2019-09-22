using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Create Parent")]
    public class CreateBlackboardParentNode:CreateBlackboardNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private BlackboardNode _blackboardNodeInput;

        protected override void CreateNode()
        {
            base.CreateNode();
            
            var clock = GetInputValue(nameof(ClockNode), ClockNode);
            var parent = GetInputValue(nameof(_blackboardNodeInput), _blackboardNodeInput);
            if (clock != null && parent != null) 
                Blackboard = new Blackboard(parent.Blackboard,clock.Clock);
        }
    }
}