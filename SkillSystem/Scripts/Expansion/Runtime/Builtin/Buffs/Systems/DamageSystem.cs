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
    /// 伤害处理系统
    /// </summary>
    public class DamageSystem<TMechanics,TDamageBuff>:IBuffCreateSystem<IcSkSEntity,TDamageBuff> 
        where TMechanics : struct, IMechanicBuff
        where TDamageBuff : struct, IDamageBuff
    {
        private readonly IStructBuffManager<IcSkSEntity> _buffManager;

        public DamageSystem(IStructBuffManager<IcSkSEntity> buffManager)
        {
            this._buffManager = buffManager;
        }

        public void Create(IcSkSEntity entity, int index)
        {
            var buffs = _buffManager.GetBuffs<TMechanics>(entity);

            var damage = _buffManager.GetBuffData<TDamageBuff>(entity, index);

            foreach (var buff in buffs)
            {
                var mechanics = buff;
                
                mechanics.Value -= damage.Value;
                
                _buffManager.SetBuffData(entity,mechanics,0);
                
                //todo 一个单位只有第一条血条会受伤
                break;
            }
        }
    }
}