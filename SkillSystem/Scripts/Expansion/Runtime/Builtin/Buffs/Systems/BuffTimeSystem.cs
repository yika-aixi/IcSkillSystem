//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:00
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems
{
    public class BuffTimeSystem:ABuffUpdateSystem
    {
        public BuffTimeSystem(IBuffManager buffManager) : base(buffManager)
        {
        }

        public override bool Filter(IEntity entity)
        {
            return BuffManager.HasBuff<IBuffDataComponent>(entity);
        }

        public override void Execute(IEntity entity)
        {
            var buffs = BuffManager.GetBuffs<IBuffDataComponent>(entity, x => x is IBuffTimeDataComponent);

            if (buffs == null)
            {
                return;
            }
            
            foreach (var dataComponent in buffs)
            {
                IBuffTimeDataComponent timeData = (IBuffTimeDataComponent) dataComponent;

                timeData.Duration -= Time.deltaTime;

                if (timeData.Duration <= 0)
                {
                    BuffManager.RemoveBuff(entity, dataComponent);
                }
            }
        }
    }
}