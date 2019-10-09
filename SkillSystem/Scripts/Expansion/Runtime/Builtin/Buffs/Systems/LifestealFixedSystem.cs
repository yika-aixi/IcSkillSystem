//using System.Collections.Generic;
//using System.Linq;
//using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
//
//namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
//{
//    /// <summary>
//    /// 固定吸血,可多个
//    /// </summary>
//    public class LifestealFixedSystem:ABuffDestroySystem<IBuffDataComponent>
//    {
//        private List<IFixedLifesteal> _fixedLifesteals;
//        private List<IMechanicBuff> _mechanicBuffs;
//
//        public LifestealFixedSystem(IBuffManager<IBuffDataComponent> buffManager) : base(buffManager)
//        {
//            _fixedLifesteals = new List<IFixedLifesteal>();
//            _mechanicBuffs = new List<IMechanicBuff>();
//        }
//
//        public override bool Filter(IEntity entity, IBuffDataComponent buff)
//        {
//            //伤害来源需要有固定吸血buff并且存在生命
//            return buff is IDamageBuff damageBuff && damageBuff.Maker != null && BuffManager.HasBuff<IFixedLifesteal>(damageBuff.Maker) && 
//                   BuffManager.HasBuff<IMechanicBuff>(damageBuff.Maker,x=>x.MechanicsType == MechanicsType.Health);
//        }
//
//        public override void Destroy(IEntity entity, IBuffDataComponent buff)
//        {
//            IDamageBuff damageBuff = (IDamageBuff) buff;
//
//            BuffManager.GetBuffs(damageBuff.Maker,_fixedLifesteals);
//
//            BuffManager.GetBuffs(damageBuff.Maker, _mechanicBuffs);
//
//            if (_mechanicBuffs.Count < 1)
//            {
//                return;
//            }
//
//            var health = _mechanicBuffs[0];
//            var maxHealth = _mechanicBuffs[1];
//            
//            foreach (var fixedLifesteal in _fixedLifesteals)
//            {
//                if (fixedLifesteal is IBuffType buffType)
//                {
//                    if (damageBuff.Type != buffType.Type)
//                    {
//                        continue;
//                    }
//                }
//
//                health.Value += fixedLifesteal.Value;
//
//                if (health.Value > maxHealth.Value)
//                {
//                    health.Value = maxHealth.Value;
//                }
//            }
//        }
//    }
//}