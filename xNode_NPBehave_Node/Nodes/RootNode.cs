using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Nodes/Root")]
    public class RootNode : NPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        private BlackboardNode _blackBoard;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        private ClockNode _clok;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        private NPBehaveNode _mainNode;
        
        // Use this for initialization
        protected override void Init()
        {
            base.Init();
        }

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