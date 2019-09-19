using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class NPBehaveNode:Node
    {
        public NPBehave.Node Node { get; protected set; }

        public override object GetValue(NodePort port)
        {
            CreateNode();
            
            return this;
        }

        protected override void Init()
        {
            CreateNode();
        }
        
        public override void OnCreateConnection(NodePort @from, NodePort to)
        {
            CreateNode();
        }

        public override void OnRemoveConnection(NodePort port)
        {
            CreateNode();
        }

        protected abstract void CreateNode();
    }
}