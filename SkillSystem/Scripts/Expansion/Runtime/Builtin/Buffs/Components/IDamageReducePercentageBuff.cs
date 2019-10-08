using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// 百分比伤害减少 buff
    /// </summary>
    public interface IDamageReducePercentageBuff:IBuffDataComponent,IBuffValueDataComponent,IBuffDescriptionComponent,IBuffType
    {
    }
    
    /// <summary>
    /// 百分比伤害减少 buff
    /// </summary>
    public interface IDamageReducePercentageStructBuff:IStructBuffDataComponent,IBuffValueDataComponent,IBuffType
    {
    }
}