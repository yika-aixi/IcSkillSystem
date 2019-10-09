//using CabinIcarus.IcSkillSystem.Runtime.Buffs;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
//
//namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Systems.StructSystem
//{
//    public abstract class AStructBuffDestroySystem:IBuffDestroySystem<StructBuffInfo>
//    {
//        protected readonly IBuffManager<IStructBuffDataComponent> BuffManager;
//
//        protected AStructBuffDestroySystem(IBuffManager<IStructBuffDataComponent> buffManager)
//        {
//            BuffManager = buffManager;
//        }
//        
//        public abstract bool Filter(IEntity entity, StructBuffInfo buff);
//        public abstract void Destroy(IEntity entity, StructBuffInfo buff);
//    }
//}