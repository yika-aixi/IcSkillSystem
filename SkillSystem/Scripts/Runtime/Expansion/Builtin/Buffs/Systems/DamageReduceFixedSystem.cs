using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    /// <summary>
    /// 固定减少伤害,如果存在多个一样的buff,只会使用最后一个
    /// </summary>
    public class DamageReduceFixedSystem:ABuffCreateSystem
    {
        private List<IDamageReduceFixedBuff> _damageReduceFixedBuffs;
        public DamageReduceFixedSystem(IBuffManager buffManager) : base(buffManager)
        {
            _damageReduceFixedBuffs = new List<IDamageReduceFixedBuff>();
        }

        public override bool Filter(IEntity entity, IBuffDataComponent buff)
        {
            return buff is IDamageBuff && BuffManager.HasBuff<IDamageReduceFixedBuff>(entity) && BuffManager.HasBuff<IMechanicBuff>(entity,x=>x.MechanicsType == MechanicsType.Health);
        }

        public override void Create(IEntity entity, IBuffDataComponent buff)
        {
            BuffManager.GetBuffs(entity,_damageReduceFixedBuffs);

            //todo 只使用最后一个减伤buff
            IDamageReduceFixedBuff damageReduceFixedBuff = _damageReduceFixedBuffs[_damageReduceFixedBuffs.Count - 1];

            IDamageBuff damageBuff = (IDamageBuff) buff;
            
            if (damageBuff.Type == damageReduceFixedBuff.Type)
            {
                damageBuff.Value -= damageReduceFixedBuff.Value;
            }
        }
    }
}