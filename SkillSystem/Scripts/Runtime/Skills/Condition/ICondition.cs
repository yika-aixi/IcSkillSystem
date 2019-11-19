using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Condition
{
    public interface ICondition
    {
        bool Check(IIcSkSEntity icSkSEntity);
    }
}