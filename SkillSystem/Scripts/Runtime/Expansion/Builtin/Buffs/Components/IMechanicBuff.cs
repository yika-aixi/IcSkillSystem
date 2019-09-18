namespace CabinIcarus.SkillSystem.Runtime.Buffs.Components
{
    public enum MechanicsType
    {
        None,
        /// <summary>
        /// 生命
        /// </summary>
        Health,
        /// <summary>
        /// 法力
        /// </summary>
        Mana,
        /// <summary>
        /// 攻击
        /// </summary>
        Attack,
        /// <summary>
        /// 魔法攻击
        /// </summary>
        Magic,
        /// <summary>
        /// 盔甲
        /// </summary>
        Armor,
        /// <summary>
        /// 法术抗性
        /// </summary>
        MagicResistance,
        /// <summary>
        /// 攻击速度
        /// </summary>
        AttackSpeed,
        /// <summary>
        /// 移动速度
        /// </summary>
        MoveSpeed,
        /// <summary>
        /// 闪避值
        /// </summary>
        Evasion,
    }
    
    /// <summary>
    /// 能力buff
    /// </summary>
    public interface IMechanicBuff:IBuffDataComponent,IBuffValueDataComponent
    {
        MechanicsType MechanicsType { get;}
    }
}