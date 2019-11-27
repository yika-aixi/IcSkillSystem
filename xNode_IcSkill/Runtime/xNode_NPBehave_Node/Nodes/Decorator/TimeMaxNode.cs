using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/TimeMax")]
    public class TimeMaxNode:ADecoratorNode<TimeMax>
    {
        [SerializeField] 
        private float _limit;
        
        [SerializeField] 
        private float _randomVariation;
        
        [SerializeField] 
        private bool _waitForChildButFailOnLimitReached;

        protected override TimeMax GetDecoratorNode()
        {
            return new TimeMax(_limit, _randomVariation, _waitForChildButFailOnLimitReached, DecorateeNode);
        }
    }
}