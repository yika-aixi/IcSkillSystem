//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月14日-19:19
//CabinIcarus.SkillSystem.Runtime

using Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Entitys;
using CabinIcarus.SkillSystem.Runtime.Buffs.Components;
using CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.SkillSystem.Scripts.Runtime.Buffs;

namespace Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Systems
{
    public abstract class ABuffDestroySystem:IBuffDestroySystem
    {
        protected readonly IBuffManager BuffManager;

        protected ABuffDestroySystem(IBuffManager buffManager)
        {
            BuffManager = buffManager;
        }

        public abstract bool Filter(IEntity entity, IBuffDataComponent buff);
        public abstract void Destroy(IEntity entity, IBuffDataComponent buff);
    }
}