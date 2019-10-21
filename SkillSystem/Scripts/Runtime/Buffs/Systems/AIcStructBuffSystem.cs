using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcStructBuffSystem<TEntity,TBuffType>: 
        IBuffCreateSystem<TEntity,TBuffType>,
        IBuffUpdateSystem,IBuffDestroySystem<TEntity,TBuffType> 
        where TEntity : struct, IIcSkSEntity, IEquatable<TEntity> 
        where TBuffType : struct, IBuffDataComponent
    {
        protected readonly IStructBuffManager<TEntity> BuffManager;

        protected AIcStructBuffSystem(IStructBuffManager<TEntity> buffManager)
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