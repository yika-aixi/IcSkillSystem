using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    public abstract class ClockNode:ANPNode
    {
        public Clock Clock { get; protected set; }

        [SerializeField,Output()]
        private ClockNode _output;

        protected override void CreateNode()
        {
            _output = this;
        }
    }
}