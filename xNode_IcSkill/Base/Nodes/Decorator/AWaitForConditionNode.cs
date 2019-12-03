using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class AWaitForConditionNode:ADecoratorNode<WaitForCondition>
    {
        [SerializeField] 
        private float _checkInterval;
        
        [SerializeField] 
        private float _randomVariance;

        protected override WaitForCondition GetDecoratorNode()
        {
            return new WaitForCondition(Condition, _checkInterval, _randomVariance, DecorateeNode);
        }

        protected abstract bool Condition();
    }
}