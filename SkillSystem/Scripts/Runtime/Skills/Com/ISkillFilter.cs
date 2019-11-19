//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月18日-23:41
//CabinIcarus.IcSkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;

namespace CabinIcarus.SkillSystem.Runtime.Skills.Com
{
    public interface ISkillFilter
    {
        /// <summary>
        /// 过滤技能
        /// </summary>
        /// <param name="icSkSEntity"></param>
        /// <returns></returns>
        bool Filter<T>(T icSkSEntity,ISkillDataComponent skill) where T : IIcSkSEntity;
    }
}