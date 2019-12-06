using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Condition
{
    public interface ICondition<in TEntity> where TEntity : IIcSkSEntity
    {
        bool Check(TEntity icSkSEntity);
    }
}