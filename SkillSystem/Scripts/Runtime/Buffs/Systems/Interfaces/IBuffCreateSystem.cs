//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:03
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces
{
    /// <summary>
    /// buff 创建系统
    /// </summary>
    public interface IBuffCreateSystem<in TEntity>:IBuffSystem where TEntity : IIcSkSEntity
    {
        void Create(TEntity entity,int index);
    }
}