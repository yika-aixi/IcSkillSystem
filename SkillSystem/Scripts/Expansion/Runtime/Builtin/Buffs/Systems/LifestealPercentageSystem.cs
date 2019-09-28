using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 百分比吸血,可叠加
    /// </summary>
    public class LifestealPercentageSystem:ABuffDestroySystem
    {
        private List<IPercentageLifesteal> _damageReducePercentageBuffs;
        public LifestealPercentageSystem(IBuffManager buffManager) : base(buffManager)
        {
            _damageReducePercentageBuffs = new List<IPercentageLifesteal>();
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            //伤害来源需要有固定吸血buff并且存在生命
            return buff is IDamageBuff damageBuff && damageBuff.Maker != null && BuffManager.HasBuff<IPercentageLifesteal>(damageBuff.Maker) && 
                   BuffManager.HasBuff<IMechanicBuff>(damageBuff.Maker,x=>x.MechanicsType == MechanicsType.Health);
        }

        public override void Destroy(IEntity entity, IBuffDataComponent buff)
        {
            IDamageBuff damageBuff = (IDamageBuff) buff;
            
            var healths = BuffManager.GetBuffs<IMechanicBuff>(damageBuff.Maker).GetEnumerator();

            healths.MoveNext();

            var health = healths.Current;
            
            BuffManager.GetBuffs(damageBuff.Maker,_damageReducePercentageBuffs);

            float per = 0;
            
            foreach (var percentageLifesteal in _damageReducePercentageBuffs)
            {
                if (percentageLifesteal is IBuffType buffType)
                {
                    if (damageBuff.Type != buffType.Type)
                    {
                        continue;
                    }
                }

                per += percentageLifesteal.Value;
            }
            
            health.Value += damageBuff.Value * per;
        }
    }
}