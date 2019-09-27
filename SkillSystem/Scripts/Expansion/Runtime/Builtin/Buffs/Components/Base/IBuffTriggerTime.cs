namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// 持续触发型buff
    /// </summary>
    public interface IBuffTriggerTime:IBuffTimeDataComponent
    {
        /// <summary>
        /// 最后的触发时间
        /// </summary>
        float LastTriggerTime { get; set; }
        
        /// <summary>
        /// 触发间隔
        /// </summary>
        float TriggerInterval { get; set; }
    }
}