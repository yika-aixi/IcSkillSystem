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
        public IcSkillGroup ChildGroup => _group;
#endif

        private IcSkillGroup _currentGroup;
        public IcSkillGroup GetGroup()
        {
            if (!_currentGroup)
            {
                _currentGroup =  (IcSkillGroup) _group.Copy();
            }

            return _currentGroup;
        }
        
        protected override NPBehave.Node GetOutValue()
        {
            if (_group == null)
            {
                return null;
            }

            GetGroup();

            _childGroupNode = _getChildGroupNode(_currentGroup);

            if (!_childGroupNode)
            {
                return null;
            }

            _childGroupNode.GetChildGroupNode = this;
            
            return _currentGroup.GetChildGroupNode((IcSkillGroup) graph);
        }

        protected override object GetPortValue(NodePort port)
        {
            return _getChildGroupNode(GetGroup()).GetInputValue<object>(port.fieldName);
        }

        private ChildGroupNode _childNode;
        private IcSkillGroup _lastGroup;
        
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

            if (_lastGroup == skillGroup && _childNode)
            {
                return _childNode;
            }
            
            foreach (var node in skillGroup.nodes)
            {
                if (node is ChildGroupNode childGroupNode)
                {
                    _lastGroup = skillGroup;
                    _childNode = childGroupNode;
                    return childGroupNode;
                }
            }

            return null;
        }
    }
}