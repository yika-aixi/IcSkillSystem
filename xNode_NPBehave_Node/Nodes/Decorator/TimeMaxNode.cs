using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/TimeMax")]
    public class TimeMaxNode:ADecoratorNode
    {
        [SerializeField] 
        private float _limit;
        
        [SerializeField] 
        private float _randomVariation;
        
        [SerializeField] 
        private bool _waitForChildButFailOnLimitReached;

        protected override void CreateNode()
        {
            base.CreateNode();

            Node = new TimeMax(_limit, _randomVariation, _waitForChildButFailOnLimitReached, DecorateeNode.Node);
        }
    }
}