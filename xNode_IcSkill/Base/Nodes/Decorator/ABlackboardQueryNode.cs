using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class ABlackboardQueryNode:AObservingDecoratorNode<BlackboardQuery>
    {
        [SerializeField]
        private string[] _keys;

        protected override BlackboardQuery GetDecoratorNode()
        {
            return new BlackboardQuery(_keys,Stops,IsConditionMet,DecorateeNode);
        }

        protected abstract bool IsConditionMet();
    }
}