using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGroup/Main")]
    public class ChildGroupNode:ANPBehaveNode<NPBehave.Node>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private NPBehave.Node _main;
        
#if UNITY_EDITOR
        public const string MainNodeFieldName = nameof(_main);
#endif
        internal GetChildGroupNode GetChildGroupNode;
        
        protected override NPBehave.Node CreateOutValue()
        {
            _main = GetInputValue(nameof(_main), _main);

            return _main;
        }
        
        protected override object GetPortValue(NodePort port)
        {
            return GetChildGroupNode.GetInputValue<object>(port.fieldName);
        }
    }
}