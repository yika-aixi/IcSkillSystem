using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Root")]
    public class RootNode : NPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        [PortTooltip("黑板 Node")]
        private BlackboardNode _blackBoard;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        [PortTooltip("Clock Node")]
        private ClockNode _clok;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        [PortTooltip("主节点")]
        private NPBehaveNode _mainNode;

        protected override void CreateNode()
        {
            var black = GetInputValue(nameof(_blackBoard),_blackBoard);
            var clok = GetInputValue(nameof(_clok), _clok);
            var mainNode = GetInputValue(nameof(_mainNode), _mainNode);

            if (black && clok && mainNode)
            {
                Node = new Root(black.Blackboard,clok.Clock,mainNode.Node);
            }
            else
            {
                if (Node != null)
                {
                    Node = null;
                }   
            }
        }
    }
}