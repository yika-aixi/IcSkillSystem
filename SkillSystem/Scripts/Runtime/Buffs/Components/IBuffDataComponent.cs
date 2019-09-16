//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-18:59
//CabinIcarus.SkillSystem.Runtime

namespace CabinIcarus.SkillSystem.Runtime.Buffs.Components
{
    /// <summary>
    /// buff 组件
    /// </summary>
    public interface IBuffDataComponent
    {
        /// <summary>
        /// buff名字
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// buff描述
        /// </summary>
        string Description { get; }

        /// <summary>
        /// buff类型
        /// </summary>
        int BuffType { get; }

        /// <summary>
        /// 来源id
        /// </summary>
        int MakerId { get; set; }
    }
}