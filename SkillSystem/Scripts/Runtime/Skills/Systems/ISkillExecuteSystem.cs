using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Systems;
using CabinIcarus.SkillSystem.Runtime.Skills.Com;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Systems
{
    public interface ISkillExecuteSystem:ISkillSystem,ISkillFilter
    {
        void Execute(IIcSkSEntity icSkSEntity,ISkillDataComponent skill);
    }
}