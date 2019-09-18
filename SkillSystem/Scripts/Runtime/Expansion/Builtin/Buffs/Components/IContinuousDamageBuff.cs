namespace CabinIcarus.SkillSystem.Runtime.Buffs.Components
{
    /// <summary>
    /// 持续伤害buff
    /// </summary>
    public interface IContinuousDamageBuff:
        IBuffDataComponent,
        IBuffValueDataComponent,
        IBuffDescriptionComponent,
        IBuffType,
        IBuffTriggerTime,
        IBuffMakerEntityComponent
    {
    }
}