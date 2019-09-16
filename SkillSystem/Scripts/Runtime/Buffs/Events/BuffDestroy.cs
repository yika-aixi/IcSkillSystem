//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:12
//CabinIcarus.SkillSystem.Runtime

using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.SkillSystem.Scripts.Runtime.Buffs.Events
{
    /// <summary>
    /// buff删除时
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="buff"></param>
    public delegate void BuffRemove(IEntity entity,IBuffDataComponent buff);
}