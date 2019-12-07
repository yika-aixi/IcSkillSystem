using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Send Message/Target")]
    public class TargetSendMessageNode:AUnitySendMessageNode
    {
        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        private GameObject _target;
        
        protected override void Send()
        {
            var target = GetInputValue(nameof(_target), _target);
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