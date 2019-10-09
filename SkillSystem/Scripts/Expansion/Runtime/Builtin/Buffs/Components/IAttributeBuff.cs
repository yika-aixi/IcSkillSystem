using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components
{
    public enum AttributeType
    {
        None,
        /// <summary>
        /// 力量
        /// </summary>
        Strength,
        /// <summary>
        /// 敏捷
        /// </summary>
        Agility,
        /// <summary>
        /// 智力
        /// </summary>
        Intelligence
    }
    
    /// <summary>
    /// 属性buff
    /// </summary>
    public interface IAttributeBuff:IBuffDataComponent,IBuffValueDataComponent
    {
        AttributeType Type { get; }
    }
    
    /// <summary>
    /// 属性buff
    /// </summary>
//    public interface IAttributeStructBuff:IStructBuffDataComponent,IBuffValueDataComponent
//    {
//        AttributeType Type { get; }
//    }
}