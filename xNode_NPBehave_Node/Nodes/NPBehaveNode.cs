using XNode;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class NPBehaveNode:Node,INPBehaveNode
    {
        public NPBehave.Node Node { get; protected set; }

        [SerializeField,Output(ShowBackingValue.Always,typeConstraint = TypeConstraint.Inherited)]
        [PortTooltip("自身返回")]
        private NPBehaveNode _output;

        public sealed override object GetValue(NodePort port)
        {
            CreateNode();
            _output = this;
            return _output;
        }

        protected abstract void CreateNode();
    }
}