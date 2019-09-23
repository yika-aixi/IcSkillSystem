using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/TimeMin")]
    public class TimeMinNode : ADecoratorNode
    {
        [SerializeField] 
        private float _limit;
        
        [SerializeField] 
        private float _randomVariation;
        
        [SerializeField] 
        private bool _waitOnFailure;

        protected override void CreateNode()
        {
            base.CreateNode();

            Node = new TimeMin(_limit, _randomVariation, _waitOnFailure, DecorateeNode.Node);
        }
    }
}