using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    /// <summary>
    /// 伤害 buff
    /// </summary>
    public interface IDamage:IBuffValueDataComponent,IBuffType
    {
    }
    
    /// <summary>
    /// 伤害 buff
    /// </summary>
    public interface IDamageBuff:IDamage,IBuffDataComponent
    {
    }
    
//    /// <summary>
//    /// 伤害 buff - 结构体
//    /// </summary>
//    public interface IDamageStructBuff:IDamage,IStructBuffDataComponent
//    {
//    }
}