using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcStructBuffSystem<TEntity>: IBuffCreateSystem<TEntity>,IBuffUpdateSystem,IBuffDestroySystem<TEntity> where TEntity : IIcSkSEntity
    {
        protected readonly IBuffManager<AIcStructBuffSystem<TEntity>,TEntity> BuffManager;

        protected AIcStructBuffSystem(IBuffManager<AIcStructBuffSystem<TEntity>,TEntity> buffManager)
        {
            BuffManager = buffManager;
        }

        public void Execute()
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