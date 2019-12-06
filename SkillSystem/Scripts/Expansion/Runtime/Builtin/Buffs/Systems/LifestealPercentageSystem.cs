using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 百分比吸血,可叠加
    /// </summary>
    public class LifestealPercentageSystem<TMechanics,TPercentageLifesteal,TDamageBuff>:IBuffDestroySystem<IIcSkSEntity> 
        where TMechanics : struct, IMechanicBuff
        where TPercentageLifesteal : struct, IPercentageLifesteal
        where TDamageBuff : struct,IDamageBuff
    {
        private readonly IStructBuffManager _buffManager;

        public LifestealPercentageSystem(IStructBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }

        public void Destroy(IIcSkSEntity entity, int index)
        {
            var damage = _buffManager.GetBuffData<TDamageBuff>(entity, index);

            var fixedLifesteals = _buffManager.GetBuffs<TPercentageLifesteal>(damage.Entity.ToIIcSkSEntity());

            if (fixedLifesteals.Count == 0)
            {
                return;
            }
            
            float lifestealValue = 0;
            
            foreach (var fixedLifesteal in fixedLifesteals)
            {
                if (fixedLifesteal.Type == damage.Type)
                {
                    lifestealValue += damage.Value * fixedLifesteal.Value;
                }
            }
            
            var lifesteal = fixedLifesteals[fixedLifesteals.Count - 1];

            var mechanicBuffs = _buffManager.GetBuffs<TMechanics>(damage.Entity.ToIIcSkSEntity());

            if (mechanicBuffs.Count == 0)
            {
                return;
            }
            
            for (var i = 0; i < mechanicBuffs.Count; i++)
            {
                var mechanicBuff = mechanicBuffs[i];
                
                if (mechanicBuff.MechanicsType == MechanicsType.Health)
                {
                    mechanicBuff.Value += lifesteal.Value;

                    //第二条血把他当最大血量
                    if (mechanicBuffs.Count >= 2)
                    {
                        if (mechanicBuff.Value > mechanicBuffs[1].Value)
                        {
                            mechanicBuff.Value = mechanicBuffs[1].Value;
                        }
                    }
                   
                    _buffManager.SetBuffData(damage.Entity.ToIIcSkSEntity(),mechanicBuff,i);
                    
                    break;
                }
            }
        }
    }
}