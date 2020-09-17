using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcStructBuffSystem<TBuffType>: 
        IBuffCreateSystem,
        IBuffUpdateSystem,IBuffDestroySystem
        where TBuffType : struct, IBuffData
    {
        protected readonly IStructBuffManager BuffManager;

        protected AIcStructBuffSystem(IStructBuffManager buffManager)
        {
            BuffManager = buffManager;
        }

        public virtual void Execute()
        {
        }

        public virtual void Create(IIcSkSEntity entity, int index)
        {
        }

        public virtual void Destroy(IIcSkSEntity entity, int index)
        {
        }
    }
}