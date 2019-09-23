using UnityEngine;
using Random = NPBehave.Random;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Random")]
    public class RandomNode:ADecoratorNode
    {
        [SerializeField]
        private float _probability;
        
        protected override void CreateNode()
        {
            base.CreateNode();
            
            Node = new Random(_probability,DecorateeNode.Node);
        }
    }
}