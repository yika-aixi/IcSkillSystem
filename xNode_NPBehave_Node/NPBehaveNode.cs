using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class NPBehaveNode<T>:Node where T : NPBehave.Node
    {
        public T Node { get; protected set; }
    }
}