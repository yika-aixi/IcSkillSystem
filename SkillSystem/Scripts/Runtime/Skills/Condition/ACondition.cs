using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Condition
{
    public abstract class ACondition:ICondition
    {
        protected readonly IBuffManager<IIcSkSEntity> _buffManager;

        protected ACondition(IBuffManager<IIcSkSEntity> buffManager)
        {
            this._buffManager = buffManager;
        }

        public abstract bool Check(IIcSkSEntity icSkSEntity);
    }
}