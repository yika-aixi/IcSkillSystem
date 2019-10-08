//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:19
//CabinIcarus.SkillSystem.Runtime

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class ABuffDestroySystem:IBuffDestroySystem
    {
        protected readonly IBuffManager<IBuffDataComponent> BuffManager;

        protected ABuffDestroySystem(IBuffManager<IBuffDataComponent> buffManager)
        {
            BuffManager = buffManager;
        }

        public abstract bool Filter(IEntity entity, IBuffDataComponent buff);
        public abstract void Destroy(IEntity entity, IBuffDataComponent buff);
    }
}