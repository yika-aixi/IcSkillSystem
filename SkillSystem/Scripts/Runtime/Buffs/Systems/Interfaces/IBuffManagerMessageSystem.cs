//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:07
//CabinIcarus.SkillSystem.Runtime

using System;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces
{
    /// <summary>
    /// buff 消息系统
    /// </summary>
    public interface IBuffManagerMessageSystem:IBuffSystem
    {
        /// <summary>
        /// buff 销毁
        /// 参数为被销毁的buff
        /// </summary>
        Action<IBuffDataComponent> OnDestroy { get; set; }
    }
}