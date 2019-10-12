using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Systems;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Manager
{
    public interface ISkillManager
    {
        void UseSkill(IIcSkSEntity icSkSEntity, ISkillDataComponent skill);

        //void RemoveSkill(IEntity entity, ISkillDataComponent skill);

        ISkillManager AddSkillSystem(ISkillExecuteSystem skillSystem);
    }
}