//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:05
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Com;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces
{
    /// <summary>
    /// buff 更新系统
    /// </summary>
    public interface IBuffUpdateSystem:IBuffSystem,IEntityFilter
    {
        void Execute(IEntity entity);
    }
}