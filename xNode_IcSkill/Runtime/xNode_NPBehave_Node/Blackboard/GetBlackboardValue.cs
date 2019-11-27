using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using NPBehave;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Blackboard Value")]
    public class GetBlackboardValue:ValueNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("no input use Blackboard of from Root")]
        private Blackboard _blackBoard;
        
        [SerializeField]
        private string _key;

        public override Type ValueType { get; } = typeof(object);

        public override bool IsChangeValueType { get; } = true;

        protected override object GetOutValue()
        {
            
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                return null;;
            }
#endif
            var blackboard = GetInputValue(nameof(_blackBoard), _blackBoard);

            if (blackboard == null)
            {
                blackboard = SkillGroup.RootNode.Blackboard;
            }
            
            
            return blackboard.Get(_key);
        }
    }
}