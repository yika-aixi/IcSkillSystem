using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class BlackboardNode:Node,INPBehaveNode
    {
        public Blackboard Blackboard { get; protected set; }

        [SerializeField,Output]
        private BlackboardNode _blackboardNode;

        public override object GetValue(NodePort port)
        {
            _blackboardNode = this;
            return _blackboardNode;
        }
    }
}