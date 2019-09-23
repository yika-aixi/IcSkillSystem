using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Blackboard Condition")]
    public class BlackboardConditionNode:AObservingDecoratorNode
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private Operator _operator;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private ValueNode _value;

        protected override void CreateNode()
        {
            base.CreateNode();
            
            ValueNode valueNode = GetInputValue(nameof(_value),_value);
            
            Node = new BlackboardCondition(_key,_operator,valueNode.Value,Stops,DecorateeNode.Node);
        }
    }
}