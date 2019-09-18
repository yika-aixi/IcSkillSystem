using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Manager
{
    public interface ISkillManager
    {
        void AddSkill(IEntity entity, ISkillDataComponent skill);

        void RemoveSkill(IEntity entity, ISkillDataComponent skill);
    }
}