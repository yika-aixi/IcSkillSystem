using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Root")]
    public class RootNode : ANPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("黑板 Node")]
        private BlackboardNode _blackBoard;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("Clock Node")]
        private ClockNode _clok;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("主节点")]
        private ANPBehaveNode _mainNode;

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