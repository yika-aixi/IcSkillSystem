using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
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
        IMakerEntity
    {
    }
    
//    /// <summary>
//    /// 持续伤害buff
//    /// </summary>
//    public interface IContinuousDamageStructBuff:
//        IStructBuffDataComponent,
//        IBuffValueDataComponent,
//        IBuffType,
//        IBuffTriggerTime
//    {
//    }
}