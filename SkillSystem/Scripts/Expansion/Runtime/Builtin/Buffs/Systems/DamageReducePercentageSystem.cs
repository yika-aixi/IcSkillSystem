using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 百分比伤害减少,如果存在多个一样的buff,只会使用最后一个
    /// </summary>
    public class DamageReducePercentageSystem<TDamageReducePercentageBuff,TDamageBuff>:IBuffCreateSystem<IIcSkSEntity>
        where TDamageReducePercentageBuff : struct,IDamageReducePercentageBuff
        where TDamageBuff : struct,IDamageBuff
    {
        private readonly IStructBuffManager _buffManager;

        public DamageReducePercentageSystem(IStructBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }

        public void Create(IIcSkSEntity entity, int index)
        {
            var fixedBuffs = _buffManager.GetBuffs<TDamageReducePercentageBuff>(entity);

            if (fixedBuffs.Count == 0)
            {
                return;
            }
            
            //todo 只使用最后一个减伤buff
            TDamageReducePercentageBuff damageReduceFixedBuff = fixedBuffs[fixedBuffs.Count - 1];

            TDamageBuff damageBuff = _buffManager.GetBuffData<TDamageBuff>(entity, index);
            
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