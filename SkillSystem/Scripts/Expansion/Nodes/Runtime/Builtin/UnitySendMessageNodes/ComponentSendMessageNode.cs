using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Send Message/Component")]
    public class ComponentSendMessageNode:AUnitySendMessageNode
    {
        [Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        private Component _component;
        
        protected override void Send()
        {
            var target = GetInputValue(nameof(_component), _component);
            
            if (IsUpwards)
            {
                target?.SendMessageUpwards(MessageName,Value,Options);
            }
            else
            {
                target?.SendMessage(MessageName,Value,Options);
            }    
        }
    }
}