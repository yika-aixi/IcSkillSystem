//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:30
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class ABuffUpdateSystem<T> : IBuffUpdateSystem where T : IBuffDataComponent
    {
        protected readonly IBuffManager<T> BuffManager;

        protected ABuffUpdateSystem(IBuffManager<T> buffManager)
        {
            BuffManager = buffManager;
        }
        
        public abstract bool Filter(IEntity entity);
        public abstract void Execute(IEntity entity);
    }
}