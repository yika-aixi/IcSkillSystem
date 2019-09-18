using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// 伤害 buff
    /// </summary>
    public interface IDamageBuff:IBuffDataComponent,IBuffValueDataComponent,IBuffMakerEntityComponent,IBuffType
    {
    }
}