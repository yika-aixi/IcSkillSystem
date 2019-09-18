//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月16日-22:40
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Com
{
    /// <summary>
    /// buff 过滤器
    /// </summary>
    public interface IBuffFilter
    {
        /// <summary>
        /// 过滤buff
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Filter(IEntity entity,IBuffDataComponent buff);
    }
}