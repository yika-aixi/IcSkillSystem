using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Blackboard Condition")]
    public class BlackboardConditionNode:AObservingDecoratorNode<BlackboardCondition>
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private Operator _operator;

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private object _value;

        protected override BlackboardCondition GetDecoratorNode()
        {
            _value = GetInputValue(nameof(_value),_value);

            return new BlackboardCondition(_key,_operator,_value,Stops,DecorateeNode);
        }
    }
}