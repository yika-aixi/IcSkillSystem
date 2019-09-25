using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Create Parent")]
    public class CreateBlackboardParentNode:CreateBlackboardNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Blackboard _blackboardNodeInput;

        protected override Blackboard GetOutValue()
        {
            var clock = GetInputValue(nameof(Clock), Clock);
            var parent = GetInputValue(nameof(_blackboardNodeInput), _blackboardNodeInput);
            if (clock != null && parent != null) 
                return new Blackboard(parent,clock);

            return null;
        }
    }
}