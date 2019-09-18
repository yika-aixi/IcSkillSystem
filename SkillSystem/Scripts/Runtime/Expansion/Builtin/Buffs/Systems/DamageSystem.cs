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

        public DamageSystem(IBuffManager buffManager) : base(buffManager)
        {
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IDamageBuff && BuffManager.HasBuff<IMechanicBuff>(entity,_healthMatch); 
        }

        private static bool _healthMatch(IMechanicBuff x)
        {
            return x.MechanicsType == MechanicsType.Health;
        }

        public override void Create(IEntity entity, IBuffDataComponent buff)
        {
            foreach (var hpBuff in BuffManager.GetBuffs<IMechanicBuff>(entity,_healthMatch))
            {
                var damageBuff = ((IDamageBuff) buff);
                
                hpBuff.Value -= damageBuff.Value;
                BuffManager.RemoveBuff(entity,buff);
                
                //todo 一个单位不应该出现多血条,所以只处理第一条buff
                return;
            }
        }
    }
}