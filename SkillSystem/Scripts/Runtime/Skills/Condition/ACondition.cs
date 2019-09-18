using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Condition
{
    public abstract class ACondition:ICondition
    {
        protected readonly IBuffManager _buffManager;

        protected ACondition(IBuffManager buffManager)
        {
            this._buffManager = buffManager;
        }

        public abstract bool Check(IEntity entity);
    }
}