using System.Collections.Generic;
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

        private List<IMechanicBuff> _buffs;

        public ManaCheck(IBuffManager buffManager) : base(buffManager)
        {
            _buffs = new List<IMechanicBuff>();
        }

        public override bool Check(IEntity entity)
        {
            _buffManager.GetBuffs<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Mana,_buffs);
            if (_buffs.Count > 0)
            {
                var buff = _buffs[0];
                
                var result = buff.Value >= NeedManaValue;

                if (result)
                {
                    buff.Value -= NeedManaValue;
                }

                return result;
            }

            return !MustNeedMana;
        }
    }
}