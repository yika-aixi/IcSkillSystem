using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcStructBuffSystem<TEntity>: IBuffCreateSystem<TEntity>,IBuffUpdateSystem,IBuffDestroySystem<TEntity> where TEntity : struct, IIcSkSEntity, IEquatable<TEntity>
    {
        protected readonly IStructBuffManager<TEntity> BuffManager;

        protected AIcStructBuffSystem(IStructBuffManager<TEntity> buffManager)
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