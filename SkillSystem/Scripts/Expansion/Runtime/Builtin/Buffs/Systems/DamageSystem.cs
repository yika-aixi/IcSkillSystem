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
    public class DamageSystem<TMechanics,TDamageBuff>:IBuffCreateSystem<IIcSkSEntity> 
        where TMechanics : struct, IMechanicBuff
        where TDamageBuff : struct, IDamageBuff
    {
//        private readonly IStructBuffManager<IcSkSEntity> _buffManager;

        private readonly BuffManager_Struct _buffManager;
        public DamageSystem(IStructBuffManager buffManager)
        {
            this._buffManager = (BuffManager_Struct) buffManager;
        }

        public void Create(IIcSkSEntity entity, int index)
        {
            var buffs = _buffManager.GetBuffsCondition<TMechanics>(entity,_getHealth);

            var damage = _buffManager.GetBuffData<TDamageBuff>(entity, index);

#if ENABLE_MANAGED_JOBS
            for (var i = 0; i < buffs.Length; i++)
#else
            for (var i = 0; i < buffs.Count; i++)
#endif
            {
                var buffInfo = buffs[i];

                var buff = buffInfo.Buff;
                
                buff.Value = buff.Value - damage.Value;

                _buffManager.SetBuffData(entity, buff, buffInfo.Index);

                //todo 一个单位只有第一条血条会受伤
                break;
            }

            _buffManager.RemoveBuff(entity, damage);
        }

        private bool _getHealth(TMechanics arg)
        {
            return arg.MechanicsType == MechanicsType.Health;
        }
    }
}