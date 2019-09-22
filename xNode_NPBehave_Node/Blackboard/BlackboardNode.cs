using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class BlackboardNode:ANPNode
    {
        public Blackboard Blackboard { get; protected set; }

        [SerializeField,Output()]
        private BlackboardNode _output;
        
        protected override void CreateNode()
        {
            _output = this;
        }
    }
}