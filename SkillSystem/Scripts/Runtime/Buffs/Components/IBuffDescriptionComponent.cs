//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月16日-22:33
//CabinIcarus.SkillSystem.Runtime

namespace CabinIcarus.SkillSystem.Runtime.Buffs.Components
{
    /// <summary>
    /// buff 描述
    /// </summary>
    public interface IBuffDescriptionComponent
    {
        /// <summary>
        /// buff名字
        /// </summary>
        string Name { get; set; } 
        
        /// <summary>
        /// buff 描述
        /// </summary>
        string Description { get; set; }
    }
}