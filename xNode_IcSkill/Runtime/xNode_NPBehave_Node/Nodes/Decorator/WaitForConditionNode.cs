using System;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/WaitForCondition")]
    public class WaitForConditionNode:ADecoratorNode<WaitForCondition>
    {
        [SerializeField] 
        private float _checkInterval;
        
        [SerializeField] 
        private float _randomVariance;

        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Func<bool> _condition;

        protected override WaitForCondition GetDecoratorNode()
        {
            _condition = GetInputValue(nameof(_condition), _condition);
            return new WaitForCondition(_condition, _checkInterval, _randomVariance, DecorateeNode);
        }
    }
}