using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class ADecoratorNode<T>:ANPBehaveNode<T> where T : Node
    {
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        protected Node DecorateeNode;

        protected sealed override T GetOutValue()
        {
            DecorateeNode = GetInputValue(nameof(DecorateeNode), DecorateeNode);

            return GetDecoratorNode();
        }

        protected abstract T GetDecoratorNode();
    }
}