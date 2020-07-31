using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Root")]
    public class RootNode : ANPBehaveNode<Root>
    {
        public int Priority;

        public bool AutoStart;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("黑板")]
        private Blackboard _blackBoard;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("Clock")]
        private Clock _clok;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("主节点")]
        private Node _mainNode;

        protected override Root CreateOutValue()
        {
            var black = GetInputValue(nameof(_blackBoard), UnityContext.GetSharedBlackboard(SharedBlackBoard));
            var clok = GetInputValue(nameof(_clok),  UnityContext.GetClock());
            var mainNode = GetInputValue<Node>(nameof(_mainNode));
            
            if (black != null && clok != null && mainNode != null)
            {
                return new Root(black,clok,mainNode);
            }

            return null;
        }
    }

    public class RoodNodeComparer:IComparer<RootNode>
    {
        public int Compare(RootNode x, RootNode y)
        {
            if (x.Priority < y.Priority)
            {
                return -1;
            }else if (x.Priority > y.Priority)
            {
                return 1;
            }

            return 0;
        }
    }
}