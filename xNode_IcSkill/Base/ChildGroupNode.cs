using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
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
        
        protected override NPBehave.Node GetOutValue()
        {
            _main = GetInputValue(nameof(_main), _main);

            return _main;
        }
    }
    
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGroup/Get")]
    public class GetChildGroupNode:ANPBehaveNode<NPBehave.Node>
    {
        [SerializeField]
        private IcSkillGroup _group;

#if UNITY_EDITOR
        public const string GroupFieldName = nameof(_group);
#endif
        
        public IcSkillGroup GetGroup()
        {
            return _group;
        }
        
        protected override NPBehave.Node GetOutValue()
        {
            if (_group == null)
            {
                return null;
            }
//            _group = GetInputValue(nameof(_group), _group);

            return _group.GetChildGroupNode((IcSkillGroup) graph);
        }

        protected override object GetPortValue(NodePort port)
        {
            return _getChildGroupNode(GetGroup()).GetInputValue<object>(port.fieldName);
        }
        
        ChildGroupNode _getChildGroupNode(IcSkillGroup skillGroup)
        {
            if (!skillGroup)
            {
                return null;
            }
            
            foreach (var node in skillGroup.nodes)
            {
                if (node is ChildGroupNode childGroupNode)
                {
                    return childGroupNode;
                }
            }

            return null;
        }
    }
}