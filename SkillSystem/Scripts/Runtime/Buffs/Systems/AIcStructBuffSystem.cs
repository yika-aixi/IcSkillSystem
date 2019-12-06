using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcStructBuffSystem<TEntity,TBuffType>: 
        IBuffCreateSystem<TEntity>,
        IBuffUpdateSystem,IBuffDestroySystem<TEntity> 
        where TEntity : IIcSkSEntity
        where TBuffType : struct, IBuffDataComponent
    {
        protected readonly IStructBuffManager BuffManager;

        protected AIcStructBuffSystem(IStructBuffManager buffManager)
        {
            BuffManager = buffManager;
        }

        public virtual void Execute()
        {
        }

        public virtual void Create(TEntity entity, int index)
        {
        }

        public virtual void Destroy(TEntity entity, int index)
        {
        }
    }
}