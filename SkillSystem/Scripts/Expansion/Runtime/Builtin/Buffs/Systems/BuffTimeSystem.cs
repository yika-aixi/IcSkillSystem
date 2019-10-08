//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:00
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System.Collections.Generic;
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
        private List<IBuffDataComponent> _buffs;

        public BuffTimeSystem(IBuffManager<IBuffDataComponent> buffManager) : base(buffManager)
        {
            _buffs = new List<IBuffDataComponent>();
        }

        public override bool Filter(IEntity entity)
        {
            return BuffManager.HasBuff<IBuffDataComponent>(entity);
        }

        public override void Execute(IEntity entity)
        {
            BuffManager.GetBuffs(entity, x => x is IBuffTimeDataComponent,_buffs);
            
            foreach (var dataComponent in _buffs)
            {
                IBuffTimeDataComponent timeData = (IBuffTimeDataComponent) dataComponent;

                timeData.Duration -= Time.deltaTime;

                if (timeData.Duration <= 0)
                {
                    BuffManager.RemoveBuffEx(entity, dataComponent);
                }
            }
        }
    }
}