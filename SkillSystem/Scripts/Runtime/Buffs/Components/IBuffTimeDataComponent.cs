//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:02
//CabinIcarus.SkillSystem.Runtime

namespace CabinIcarus.SkillSystem.Runtime.Buffs.Components
{
    /// <summary>
    /// buff 时间
    /// </summary>
    public interface IBuffTimeDataComponent:IBuffDataComponent
    {
        /// <summary>
        /// 持续时间
        /// </summary>
        float Duration { get; set;}
    }
}