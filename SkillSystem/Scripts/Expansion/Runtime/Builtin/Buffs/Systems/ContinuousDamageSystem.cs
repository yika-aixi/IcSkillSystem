using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 持续伤害
    /// </summary>
    public class ContinuousDamageSystem<T>:ABuffUpdateSystem,IBuffCreateSystem where T : IDamageBuff,new()
    {
        private List<IContinuousDamageBuff> _continuousBuffs;
        public ContinuousDamageSystem(IBuffManager buffManager) : base(buffManager)
        {
            _continuousBuffs = new List<IContinuousDamageBuff>();
        }
        public override bool Filter(IEntity entity)
        {
            return BuffManager.HasBuff<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Health);
        }
        public override void Execute(IEntity entity)
        {
            BuffManager.GetBuffs(entity,_continuousBuffs);
            for (var i = 0; i < _continuousBuffs.Count; i++)
            {
                var buff = _continuousBuffs[i];
                buff.Duration -= Time.deltaTime;
                if (buff.Duration > 0)
                {
                    if (buff.LastTriggerTime - buff.Duration >= buff.TriggerInterval)
                    {
                        buff.LastTriggerTime = buff.Duration;
                        
                        BuffManager.AddBuff(entity,new T()
                        {
                            Maker = buff.Maker,
                            Type = buff.Type,
                            Value = buff.Value
                        });
                    }
                }
                else
                {
                    BuffManager.RemoveBuff(entity,buff);
                }
            }
        }

        #region Init 

        public bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return BuffManager.HasBuff<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Health) && buff is IContinuousDamageBuff;
        }
        public void Create(IEntity entity, IBuffDataComponent buff)
        {
            IContinuousDamageBuff continuousDamageBuff = (IContinuousDamageBuff) buff;
            continuousDamageBuff.LastTriggerTime = continuousDamageBuff.Duration;
        }

        #endregion
    }
}