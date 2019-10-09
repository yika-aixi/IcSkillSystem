//using System.Collections.Generic;
//using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
//using UnityEngine;
//
//namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
//{
//    /// <summary>
//    /// 持续伤害
//    /// </summary>
//    public class ContinuousDamageSystem<T>:ABuffUpdateSystem<IBuffDataComponent>,IBuffCreateSystem<IBuffDataComponent> where T : IDamageBuff,new()
//    {
//        private List<IContinuousDamageBuff> _continuousBuffs;
//        public ContinuousDamageSystem(IBuffManager<IBuffDataComponent> buffManager) : base(buffManager)
//        {
//            _continuousBuffs = new List<IContinuousDamageBuff>();
//        }
//        public override bool Filter(IEntity entity)
//        {
//            return BuffManager.HasBuff<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Health);
//        }
//        public override void Execute(IEntity entity)
//        {
//            BuffManager.GetBuffs(entity,_continuousBuffs);
//            for (var i = 0; i < _continuousBuffs.Count; i++)
//            {
//                var buff = _continuousBuffs[i];
//            
//                if (buff.LastTriggerTime - buff.Duration >= buff.TriggerInterval)
//                {
//                    buff.LastTriggerTime = buff.Duration;
//                    
//                    BuffManager.CreateAndAddBuff<T>(entity, x =>
//                    {
//                        x.Maker = buff.Maker;
//                        x.Type = buff.Type;
//                        x.Value = buff.Value;
//                    });
//                }
//            }
//        }
//
//        #region Init 
//
//        public bool Filter(IEntity entity, IBuffDataComponent buff)
//        {
//            return BuffManager.HasBuff<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Health) && buff is IContinuousDamageBuff;
//        }
//        public void Create(IEntity entity, IBuffDataComponent buff)
//        {
//            IContinuousDamageBuff continuousDamageBuff = (IContinuousDamageBuff) buff;
//            continuousDamageBuff.LastTriggerTime = continuousDamageBuff.Duration;
//        }
//
//        #endregion
//    }
//}