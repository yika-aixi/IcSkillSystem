//using CabinIcarus.IcSkillSystem.Runtime.Buffs;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
//
//namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems.StructSystem
//{
//    public abstract class AStructBuffCreateSystem : IBuffCreateSystem<StructBuffInfo>
//    {
//        protected readonly IBuffManager<IStructBuffDataComponent> BuffManager;
//
//        protected AStructBuffCreateSystem(IBuffManager<IStructBuffDataComponent> buffManager)
//        {
//            BuffManager = buffManager;
//        }
//        
//        public abstract bool Filter(IEntity entity, StructBuffInfo buff);
//        public abstract void Create(IEntity entity, StructBuffInfo buff);
//    }
//}