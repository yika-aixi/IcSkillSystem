using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class NPBehaveNode:Node,INPBehaveNode
    {
        public NPBehave.Node Node { get; protected set; }

        public override object GetValue(NodePort port)
        {
            CreateNode();
            
            return this;
        }

        protected abstract void CreateNode();
    }
}