using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Root Node")]
    public class RootNode : NPBehaveNode<Root>
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        private BlackboardNode _blackBoard;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        private ClockNode _clok;
        
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override)]
        private NPBehaveNode<NPBehave.Node> _mainNode;

        [SerializeField,Output]
        private RootNode _rootOut;
        
        // Use this for initialization
        protected override void Init()
        {
            base.Init();

        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port)
        {
//            if (port.fieldName == nameof(_rootOut))
//            {
//                    
//            }

            var black = GetInputValue(nameof(_blackBoard),_blackBoard);
            var clok = GetInputValue(nameof(_clok), _clok);
            var mainNode = GetInputValue(nameof(_mainNode), _mainNode);
            
            Node = new Root(black.Blackboard,clok.Clock,mainNode.Node);

            return this;
        }
    }
}