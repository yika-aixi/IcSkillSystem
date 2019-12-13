using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Blackboard/Get Blackboard Value")]
    public class GetBlackboardValue:DynamicValueNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("no input use Blackboard of from Root")]
        private Blackboard _blackBoard;
        
        [SerializeField]
        private string _key;

        protected override object GetDynamicValue()
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