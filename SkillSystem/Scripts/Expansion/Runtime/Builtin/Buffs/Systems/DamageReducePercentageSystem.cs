using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 百分比伤害减少,如果存在多个一样的buff,只会使用最后一个
    /// </summary>
    public class DamageReducePercentageSystem:ABuffCreateSystem<IBuffDataComponent>
    {
        private List<IDamageReducePercentageBuff> _damageReducePercentageBuffs;
        public DamageReducePercentageSystem(IBuffManager<IBuffDataComponent> buffManager) : base(buffManager)
        {
            _damageReducePercentageBuffs = new List<IDamageReducePercentageBuff>();
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IDamageBuff && BuffManager.HasBuff<IDamageReducePercentageBuff>(entity) && BuffManager.HasBuff<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Health);
        }

        public override void Create(IEntity entity, IBuffDataComponent buff)
        {
            BuffManager.GetBuffs(entity,_damageReducePercentageBuffs);

            //todo 只使用最后一个减伤buff
            IDamageReducePercentageBuff damageReduceFixedBuff = _damageReducePercentageBuffs[_damageReducePercentageBuffs.Count - 1];

            IDamageBuff damageBuff = (IDamageBuff) buff;
            
            if (damageBuff.Type == damageReduceFixedBuff.Type)
            {
                damageBuff.Value -= damageBuff.Value * damageReduceFixedBuff.Value;
                if (damageBuff.Value <= 0)
                {
                    damageBuff.Value = 0;
                }
            }
        }
    }
}