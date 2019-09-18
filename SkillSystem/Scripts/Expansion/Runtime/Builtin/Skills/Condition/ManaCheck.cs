using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Skills.Condition
{
    /// <summary>
    /// 法力值检查
    /// </summary>
    public class ManaCheck:ACondition
    {
        public float NeedManaValue;
        
        /// <summary>
        /// 必须需要魔法值
        /// false的话如果没有魔法值也可以释放,有魔法值会忽略
        /// </summary>
        public bool MustNeedMana = true;
        
        public ManaCheck(IBuffManager buffManager) : base(buffManager)
        {
        }

        public override bool Check(IEntity entity)
        {
            if (_buffManager.GetBuffs<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Mana) != null)
            {
                var buffs = _buffManager.GetBuffs<IMechanicBuff>(entity).GetEnumerator();
                
                buffs.MoveNext();
                
                return buffs.Current.Value >= NeedManaValue;
            }

            return !MustNeedMana;
        }
    }
}