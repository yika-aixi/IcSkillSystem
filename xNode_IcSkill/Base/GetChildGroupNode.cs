using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGroup/Get")]
    public class GetChildGroupNode:ANPBehaveNode<NPBehave.Node>
    {
        [SerializeField]
        private IcSkillGroup _group;

        private ChildGroupNode _childGroupNode;

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

            _childGroupNode = _getChildGroupNode(_group);

            if (!_childGroupNode)
            {
                return null;
            }

            _childGroupNode.GetChildGroupNode = this;
            
            return _group.GetChildGroupNode((IcSkillGroup) graph);
        }

        protected override object GetPortValue(NodePort port)
        {
            return _getChildGroupNode(GetGroup()).GetInputValue<object>(port.fieldName);
        }
        
        ChildGroupNode _getChildGroupNode(IcSkillGroup skillGroup)
        {
            if (_childGroupNode)
            {
                return _childGroupNode;
            }
            
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