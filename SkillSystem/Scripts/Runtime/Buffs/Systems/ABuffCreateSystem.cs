////创建者:Icarus
////手动滑稽,滑稽脸
////ヾ(•ω•`)o
////https://www.ykls.app
////2019年09月15日-18:59
////CabinIcarus.SkillSystem.Runtime
//
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
//
//namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
//{
//    public abstract class ABuffCreateSystem<T> : IBuffCreateSystem<T> where T : IBuffDataComponent
//    {
//        protected readonly IBuffManager<T> BuffManager;
//
//        protected ABuffCreateSystem(IBuffManager<T> buffManager)
//        {
//            BuffManager = buffManager;
//        }
//
//        public abstract bool Filter(IEntity entity, T buff);
//        public abstract void Create(IEntity entity, T buff);
//    }
//}