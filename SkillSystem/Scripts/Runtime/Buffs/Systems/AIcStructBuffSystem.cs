using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;

namespace CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems
{
    public abstract class AIcStructBuffSystem: IBuffCreateSystem,IBuffUpdateSystem,IBuffDestroySystem
    {
        protected readonly INewBuffManager<AIcStructBuffSystem> BuffManager;

        protected AIcStructBuffSystem(INewBuffManager<AIcStructBuffSystem> buffManager)
        {
            BuffManager = buffManager;
        }

        public void Execute()
        {
        }

        public virtual void Create(IcSkSEntity entity, int index)
        {
        }

        public virtual void Destroy(IcSkSEntity entity, int index)
        {
        }
    }
}