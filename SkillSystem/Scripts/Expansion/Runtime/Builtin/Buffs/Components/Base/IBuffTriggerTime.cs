namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// buff触发事件
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