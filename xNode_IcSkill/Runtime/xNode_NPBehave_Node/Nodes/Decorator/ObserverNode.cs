using XNode;
using Node = NPBehave.Node;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Observer")]
    public class ObserverNode:AObserverNode
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Node _start;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Node _stop;

        [Output()]
        private bool _stopResult;
        
        protected override void OnStop(bool result)
        {
            _stopResult = result;
            var node = GetInputValue(nameof(_stop), _stop);
            _executeNode(node);
        }

        protected override void OnStart()
        {
            var node = GetInputValue(nameof(_start), _start);
            _executeNode(node);
        }

        void _executeNode(Node node)
        {
            if (node != null)
            {
                if (node.RootNode == null)
                {
                    node.SetRoot(OutValue.RootNode);
                }
                
                node.Start();
            }
        }

        protected override object GetPortValue(NodePort port)
        {
            if (port.fieldName == nameof(_stopResult))
            {
                return _stopResult;
            }
            return base.GetPortValue(port);
        }
    }
}