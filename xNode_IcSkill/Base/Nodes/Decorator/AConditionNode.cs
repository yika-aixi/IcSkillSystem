//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月22日-00:08
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class AConditionNode:AObservingDecoratorNode<Condition>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private ValueInfo<float> _checkInterval;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private ValueInfo<float> _randomVariance;

        protected sealed override Condition GetDecoratorNode()
        {
            return new Condition(_condition,Stops,GetInputValue(nameof(_checkInterval),_checkInterval),
                GetInputValue(nameof(_randomVariance),_randomVariance),DecorateeNode);
        }

        bool _condition()
        {
            if (!SkillGraph.IsActive())
            {
                return true;
            }
            
            return Condition();
        }
        
        protected abstract bool Condition();
    }
}