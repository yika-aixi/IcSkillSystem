using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Blackboard Condition")]
    public class BlackboardConditionNode:AObservingDecoratorNode<BlackboardCondition>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private string _key;

        [SerializeField]
        private Operator _operator;

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private object _value;

        protected override BlackboardCondition GetDecoratorNode()
        {
            return new BlackboardCondition(GetInputValue(nameof(_key),_key),_operator,GetInputValue(nameof(_value),_value),Stops,DecorateeNode);
        }
    }
}