using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [Node.CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Blackboard Value")]
    public class GetBlackboardValue:ValueNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("黑板 Node")]
        private BlackboardNode _blackBoardNode;
        
        [SerializeField]
        private string _key;
        
        public override object Value => _getValue();

        public Blackboard Blackboard;

        protected override void Init()
        {
            base.Init();

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            Blackboard = GetInputValue(nameof(_blackBoardNode), _blackBoardNode).Blackboard;
        }
        
        private object _getValue()
        {
            return Blackboard?.Get(_key);
        }
    }
}