namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Animator/Reset Trigger")]
    public class AnimatorResetTriggerNode:AAnimatorSetXXXNode
    {
        protected override void NameMode()
        {
            Anim.ResetTrigger(Name);
        }

        protected override void HashMode(in int hash)
        {
            Anim.ResetTrigger(hash);
        }
    }
}