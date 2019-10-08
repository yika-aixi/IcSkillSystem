using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// 固定伤害减少 buff
    /// </summary>
    public interface IDamageReduceFixedBuff:IBuffDataComponent,IBuffValueDataComponent,IBuffDescriptionComponent,IBuffType
    {
    }
    
    /// <summary>
    /// 固定伤害减少 buff
    /// </summary>
    public interface IDamageReduceFixedStructBuff:IStructBuffDataComponent,IBuffValueDataComponent,IBuffType
    {
    }
}