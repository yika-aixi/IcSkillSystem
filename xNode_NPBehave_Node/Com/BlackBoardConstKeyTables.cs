//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月20日-00:03
//Assembly-CSharp

using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Manager;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com
{
    public static class BlackBoardConstKeyTables
    {
        /// <summary>
        /// 技能管理器 key
        /// </summary>
        public static readonly string SkillManager = nameof(ISkillManager);
        
        /// <summary>
        /// buff 管理器 key
        /// </summary>
        public static readonly string BuffManager = nameof(IBuffManager);
        
        /// <summary>
        /// 使用技能的实体 key
        /// </summary>
        public static readonly string UseSkillEntity = "Use Skill Entity";
    }
}