using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// 伤害 buff
    /// </summary>
    public interface IDamage:IBuffValueDataComponent,IBuffType,IMakerEntity
    {
    }
    
    /// <summary>
    /// 伤害 buff
    /// </summary>
    public interface IDamageBuff:IDamage,IBuffDataComponent
    {
    }
}