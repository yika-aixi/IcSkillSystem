using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Systems;

namespace CabinIcarus.IcSkillSystem.Runtime.Skills.Systems
{
    public interface ISkillExecuteSystem:ISkillSystem
    {
        void Execute(IEntity entity,ISkillDataComponent skill);
    }
}