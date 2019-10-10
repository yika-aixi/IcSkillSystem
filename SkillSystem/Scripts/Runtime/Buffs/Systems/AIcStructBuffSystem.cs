using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcBuffSystem : IBuffCreateSystem,IBuffUpdateSystem,IBuffDestroySystem
    {
//        protected readonly IBuffManager<T> BuffManager;
//
//        protected AIcBuffSystem(IBuffManager<T> buffManager)
//        {
//            BuffManager = buffManager;
//        }
        
        public abstract bool Filter(bu'f'f'f);
        public abstract void Destroy();
        public abstract void Execute();
        public abstract void Create();
    }
}