using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGraph/Get")]
    public class GetChildGraphNode:ANPBehaveNode<NPBehave.Node>
    {
        [SerializeField]
        private IcSkillGraph _graph;

        private ChildGraphNode _childGraphNode;

#if UNITY_EDITOR
        public const string GroupFieldName = nameof(_graph);
        public IcSkillGraph ChildGraph => _graph;
#endif

        private IcSkillGraph _currentGraph;
        public IcSkillGraph GetGroup()
        {
            if (!_currentGraph)
            {
                _currentGraph =  (IcSkillGraph) _graph.Copy();
            }

            return _currentGraph;
        }
        
        protected override NPBehave.Node CreateOutValue()
        {
            if (_graph == null)
            {
                return null;
            }

            GetGroup();

            _childGraphNode = _getChildGroupNode(_currentGraph);

            if (!_childGraphNode)
            {
                return null;
            }

            _childGraphNode.GetChildGraphNode = this;
            
            return _currentGraph.GetChildGroupNode((IcSkillGraph) ((Node) this).graph);
        }

        protected override object GetPortValue(NodePort port)
        {
            return _getChildGroupNode(GetGroup()).GetInputValue<object>(port.fieldName);
        }

        private ChildGraphNode _childNode;
        private IcSkillGraph _lastGraph;
        
        ChildGraphNode _getChildGroupNode(IcSkillGraph skillGraph)
        {
            if (_childGraphNode)
            {
                return _childGraphNode;
            }
            
            if (!skillGraph)
            {
                return null;
            }

            if (_lastGraph == skillGraph && _childNode)
            {
                return _childNode;
            }
            
            foreach (var node in skillGraph.nodes)
            {
                if (node is ChildGraphNode childGroupNode)
                {
                    _lastGraph = skillGraph;
                    _childNode = childGroupNode;
                    return childGroupNode;
                }
            }

            return null;
        }
    }
}