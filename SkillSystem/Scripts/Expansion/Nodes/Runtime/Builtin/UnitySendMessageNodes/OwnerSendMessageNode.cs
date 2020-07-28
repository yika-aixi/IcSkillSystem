namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenuAttribute("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Send Message/Owner")]
    public class OwnerSendMessageNode:AUnitySendMessageNode
    {
        protected override void Send()
        {
            if (!SkillGraph.Owner)
            {
                return;
            }
            
            if (IsUpwards)
            {
                SkillGraph.Owner.SendMessageUpwards(MessageName,Value,Options);
            }
            else
            {
                SkillGraph.Owner.SendMessage(MessageName,Value,Options);
            }
        }
    }
}