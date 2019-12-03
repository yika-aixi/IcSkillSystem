//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-23:12
//Assembly-CSharp

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Use")]
    public class UseSkillNodeNodeAction:AUseSkillNode
    {
        protected override void UseSkill()
        {
            SkillManager.UseSkill(Target,Skill);
        }
    }
}