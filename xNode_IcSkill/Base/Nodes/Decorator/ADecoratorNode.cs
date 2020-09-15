using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class ADecoratorNode<T>:ANPBehaveNode<T> where T : NPBehave.Decorator
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        protected Node _decorateeNode;

        protected Node DecorateeNode;
        protected sealed override T CreateOutValue()
        {
            DecorateeNode = GetInputValue(nameof(_decorateeNode), _decorateeNode);

            return GetDecoratorNode();
        }

        protected abstract T GetDecoratorNode();
    }
}