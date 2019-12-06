using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 持续伤害
    /// </summary>
    public class ContinuousDamageSystem<T,TDamageBuff>:AIcStructBuffSystem<IIcSkSEntity,TDamageBuff> where T:struct,IContinuousDamageBuff where TDamageBuff : struct,IDamageBuff
    {
        public override void Execute()
        {
            foreach (var entity in BuffManager.Entitys)
            {
                var buffs = BuffManager.GetBuffs<T>(entity);

                for (var i = 0; i < buffs.Count; i++)
                {
                    var buff = buffs[i];

                    if (buff.LastTriggerTime - buff.Duration >=
                        buff.TriggerInterval)
                    {
                        buff.LastTriggerTime = buff.Duration;

                        BuffManager.AddBuff(entity, new TDamageBuff()
                        {
                            Entity = buff.Entity,
                            Type = buff.Type,
                            Value = buff.Value,
                        });
                    }
                    
                    BuffManager.SetBuffData(entity,buff,i);
                }
            }
        }

        #region Init 

        public override void Create(IIcSkSEntity entity, int index)
        {
            var buff = BuffManager.GetBuffData<T>(entity, index);
            
            buff.LastTriggerTime =  buff.Duration;
        }

        #endregion

        public ContinuousDamageSystem(IStructBuffManager<IIcSkSEntity>  buffManager) : base(buffManager)
        {
        }
    }
}