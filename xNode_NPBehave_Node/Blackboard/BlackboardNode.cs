using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class BlackboardNode:ANPBehaveNode<BlackboardNode>
    {
        public Blackboard Blackboard { get; protected set; }
    }
}