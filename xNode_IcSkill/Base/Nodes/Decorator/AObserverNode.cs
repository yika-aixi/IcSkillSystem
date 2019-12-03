using NPBehave;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    public abstract class AObserverNode:ADecoratorNode<Observer>
    {
        protected override Observer GetDecoratorNode()
        {
            return new Observer(OnStart,OnStop,DecorateeNode);
        }

        protected abstract void OnStop(bool result);

        protected abstract void OnStart();
    }
}