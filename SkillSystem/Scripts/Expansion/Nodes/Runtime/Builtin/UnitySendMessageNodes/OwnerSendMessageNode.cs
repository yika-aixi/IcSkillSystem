using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Send Message/Owner")]
    public class OwnerSendMessageNode:AUnitySendMessageNode
    {
        protected override void Send()
        {
            if (IsUpwards)
            {
                SkillGroup.Owner?.SendMessageUpwards(MessageName,Value,Options);
            }
            else
            {
                SkillGroup.Owner?.SendMessage(MessageName,Value,Options);
            }
        }
    }
}