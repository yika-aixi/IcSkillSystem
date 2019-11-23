//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-23:12
//Assembly-CSharp

using Action = System.Action;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Runtime.Nodes.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Use/Action")]
    public class UseSkillNodeNodeAction:AUseSkillNode<Action>
    {
        protected override Action UseSkill()
        {
            return () => SkillManager.UseSkill(Target,Skill);
        }
    }
}