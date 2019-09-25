using System;
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
        [PortTooltip("黑板")]
        private Blackboard _blackBoard;
        
        [SerializeField]
        private string _key;

        public override Type ValueType { get; set; }
        
        protected override object GetOutValue()
        {
            
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;;
            }
#endif
            var blackboard = GetInputValue(nameof(_blackBoard), _blackBoard);
            return blackboard?.Get(_key);
        }
    }
}