using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/ChildGroup/Get")]
    public class GetChildGroupNode:ANPBehaveNode<NPBehave.Node>
    {
        [SerializeField]
        private IcSkillGraph graph;

        private ChildGroupNode _childGroupNode;

#if UNITY_EDITOR
        public const string GroupFieldName = nameof(graph);
        public IcSkillGraph ChildGraph => graph;
#endif

        private IcSkillGraph _currentGraph;
        public IcSkillGraph GetGroup()
        {
            if (!_currentGraph)
            {
                _currentGraph =  (IcSkillGraph) graph.Copy();
            }

            return _currentGraph;
        }
        
        protected override NPBehave.Node CreateOutValue()
        {
            if (graph == null)
            {
                return null;
            }

            GetGroup();

            _childGroupNode = _getChildGroupNode(_currentGraph);

            if (!_childGroupNode)
            {
                return null;
            }

            _childGroupNode.GetChildGroupNode = this;
            
            return _currentGraph.GetChildGroupNode((IcSkillGraph) ((Node) this).graph);
        }

        protected override object GetPortValue(NodePort port)
        {
            return _getChildGroupNode(GetGroup()).GetInputValue<object>(port.fieldName);
        }

        private ChildGroupNode _childNode;
        private IcSkillGraph _lastGraph;
        
        ChildGroupNode _getChildGroupNode(IcSkillGraph skillGraph)
        {
            if (_childGroupNode)
            {
                return _childGroupNode;
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
                if (node is ChildGroupNode childGroupNode)
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