//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月17日-22:09
//CabinIcarus.IcSkillSystem.Expansion.Runtime

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Actions/Animator/Trigger")]
    public class AnimatorTriggerNode:AAnimatorSetXXXNode
    {
        protected override void HashMode(in int hash)
        {
            Anim.SetTrigger(hash);
        }
    }
}