using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Value Equals Or NoEquals Condition")]
    public class ValueEqualsConditionNode:AObservingDecoratorNode<Condition>
    {
        [SerializeField]
        private bool _equals;
        
        [SerializeField]
        private float _checkInterval;

        [SerializeField]
        private float _randomVariance;

        [Input(ShowBackingValue.Always,ConnectionType.Override)]
        private object _aValue;
        
        [Input(ShowBackingValue.Always,ConnectionType.Override)]
        private object _bValue;
       
        protected override Condition GetDecoratorNode()
        {
            return new Condition(_compared,Stops,_checkInterval,_randomVariance,DecorateeNode);
        }

        private bool _compared()
        {
            var aValue = GetInputValue(nameof(_aValue), _aValue);
            var bValue = GetInputValue(nameof(_bValue), _bValue);

            if (_equals)
            {
                return aValue.Equals(bValue);
            }

            return !aValue.Equals(bValue);
        }
    }
}