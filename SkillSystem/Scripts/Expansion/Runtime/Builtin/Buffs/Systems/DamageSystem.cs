using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 伤害处理系统
    /// </summary>
    public class DamageSystem:ABuffCreateSystem
    {
        private List<IMechanicBuff> _buffs;

        public DamageSystem(IBuffManager<IBuffDataComponent> buffManager) : base(buffManager)
        {
            _buffs = new List<IMechanicBuff>();
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IDamageBuff; 
        }

        private static bool _healthMatch(IMechanicBuff x)
        {
            return x.MechanicsType == MechanicsType.Health;
        }

        public override void Create(IEntity entity, IBuffDataComponent buff)
        {
            BuffManager.GetBuffs(entity, _healthMatch, _buffs);
            
            foreach (var hpBuff in _buffs)
            {
                var damageBuff = ((IDamageBuff) buff);
                
                hpBuff.Value -= damageBuff.Value;
                
                //todo 一个单位只有第一条血条会受伤
                break;
            }
            
            BuffManager.RemoveBuffEx(entity,buff);

        }
    }
}