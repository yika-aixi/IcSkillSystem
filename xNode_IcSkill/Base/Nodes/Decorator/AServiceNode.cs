using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class AServiceNode:ADecoratorNode<Service>
    {
        [SerializeField]
        private float _interval;

        [SerializeField] 
        private float _randomVariation;

        protected override Service GetDecoratorNode()
        {
            return new Service(_interval, _randomVariation,Execute, DecorateeNode);
        }

        protected abstract void Execute();
    }
}