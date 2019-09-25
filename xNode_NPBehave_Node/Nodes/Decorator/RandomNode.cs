using UnityEngine;
using Random = NPBehave.Random;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Random")]
    public class RandomNode:ADecoratorNode<Random>
    {
        [SerializeField]
        private float _probability;

        protected override Random GetDecoratorNode()
        {
            return new Random(_probability,DecorateeNode);
        }
    }
}