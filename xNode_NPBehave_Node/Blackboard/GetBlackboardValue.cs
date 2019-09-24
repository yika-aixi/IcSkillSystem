using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;
using XNode;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Blackboard Value")]
    public class GetBlackboardValue:ValueNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("黑板 Node")]
        private BlackboardNode _blackBoardNode;
        
        [SerializeField,Output()]
        [PortTooltip("获取黑板值节点出口,如果你需要的是值请连接值出口")]
        private GetBlackboardValue _getBlackboard;
        
        [SerializeField]
        private string _key;

        public const string TypeValueOutPortName = "TypeValue";
        
        public override object Value => _getValue();

        public Blackboard Blackboard;

        public override object GetValue(NodePort port)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return base.GetValue(port);;
            }
#endif
            Blackboard = GetInputValue(nameof(_blackBoardNode), _blackBoardNode).Blackboard;

            _getBlackboard = this;

            return base.GetValue(port);
            
        }

        private object _getValue()
        {
            return Blackboard?.Get(_key);
        }
    }
}