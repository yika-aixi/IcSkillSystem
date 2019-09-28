using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 固定吸血,可多个
    /// </summary>
    public class LifestealFixedSystem:ABuffDestroySystem
    {
        private List<IFixedLifesteal> _fixedLifesteals;
        public LifestealFixedSystem(IBuffManager buffManager) : base(buffManager)
        {
            _fixedLifesteals = new List<IFixedLifesteal>();
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            //伤害来源需要有固定吸血buff并且存在生命
            return buff is IDamageBuff damageBuff && damageBuff.Maker != null && BuffManager.HasBuff<IFixedLifesteal>(damageBuff.Maker) && 
                   BuffManager.HasBuff<IMechanicBuff>(damageBuff.Maker,x=>x.MechanicsType == MechanicsType.Health);
        }

        public override void Destroy(IEntity entity, IBuffDataComponent buff)
        {
            IDamageBuff damageBuff = (IDamageBuff) buff;

            BuffManager.GetBuffs(damageBuff.Maker,_fixedLifesteals);

            var healths = BuffManager.GetBuffs<IMechanicBuff>(damageBuff.Maker).GetEnumerator();

            healths.MoveNext();

            var health = healths.Current;
            
            foreach (var fixedLifesteal in _fixedLifesteals)
            {
                if (fixedLifesteal is IBuffType buffType)
                {
                    if (damageBuff.Type != buffType.Type)
                    {
                        continue;
                    }
                }

                health.Value += fixedLifesteal.Value;
            }
        }
    }
}