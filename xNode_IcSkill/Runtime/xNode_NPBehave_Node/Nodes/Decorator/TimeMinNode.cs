using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/TimeMin")]
    public class TimeMinNode : ADecoratorNode<TimeMin>
    {
        [SerializeField] 
        private float _limit;
        
        [SerializeField] 
        private float _randomVariation;
        
        [SerializeField] 
        private bool _waitOnFailure;

        protected override TimeMin GetDecoratorNode()
        {
            return new TimeMin(_limit, _randomVariation, _waitOnFailure, DecorateeNode);
        }
    }
}