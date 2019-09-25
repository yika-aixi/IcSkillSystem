using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Root")]
    public class RootNode : ANPBehaveNode<Root>
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("黑板")]
        private Blackboard _blackBoard;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("Clock")]
        private Clock _clok;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("主节点")]
        private Node _mainNode;

        protected override Root GetOutValue()
        {
            var black = GetInputValue(nameof(_blackBoard),_blackBoard);
            var clok = GetInputValue(nameof(_clok), _clok);
            var mainNode = GetInputValue<Node>(nameof(_mainNode));
            if (black != null && clok != null && mainNode != null)
            {
                return new Root(black,clok,mainNode);
            }

            return null;
        }
    }
}