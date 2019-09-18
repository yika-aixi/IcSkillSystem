using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Manager;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Systems;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Skills.Manager
{
    public class SkillManager:ISkillManager
    {
        private List<ISkillExecuteSystem> _skillSystem;

        public SkillManager()
        {
            _skillSystem = new List<ISkillExecuteSystem>();
        }

        public void UseSkill(IEntity entity, ISkillDataComponent skill)
        {
            foreach (var system in _skillSystem)
            {
                //todo 缺少过滤
                system.Execute(entity,skill);
            }
        }

//        public void RemoveSkill(IEntity entity, ISkillDataComponent skill)
//        {
//        }

        public void AddSkillSystme(ISkillExecuteSystem skillSystem)
        {
            _skillSystem.Add(skillSystem);
        }
    }
}