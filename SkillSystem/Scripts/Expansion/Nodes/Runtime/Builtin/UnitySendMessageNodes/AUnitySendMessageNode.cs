using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;
using UnityEngine.Serialization;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
//    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/")]
    public abstract class AUnitySendMessageNode:ANPBehaveNode<Action>
    {
        [SerializeField] 
        protected SendMessageOptions Options;
        
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private string _messageName;

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("contain ancestor")]
        private bool _isUpwards;
        
        [Input(ShowBackingValue.Always,ConnectionType.Override)]
        private object _value;

        protected string MessageName => GetInputValue(nameof(_messageName),_messageName);

        protected object Value => GetInputValue(nameof(_value),_value);

        public bool IsUpwards => GetInputValue(nameof(_isUpwards),_isUpwards);

        protected override Action GetOutValue()
        {
            return new Action(Send);
        }

        protected abstract void Send();
    }
}