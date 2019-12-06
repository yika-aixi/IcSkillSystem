//using System.Collections.Generic;
//using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
//using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
//using CabinIcarus.IcSkillSystem.Runtime.Skills.Manager;
//using CabinIcarus.IcSkillSystem.Runtime.Skills.Systems;
//
//namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Skills.Manager
//{
//    public class SkillManager:ISkillManager
//    {
//        private List<ISkillExecuteSystem> _skillSystem;
//
//        public SkillManager()
//        {
//            _skillSystem = new List<ISkillExecuteSystem>();
//        }
//
//        public void UseSkill(IIcSkSEntity icSkSEntity, ISkillDataComponent skill)
//        {
//            foreach (var system in _skillSystem)
//            {
//                if (system.Filter(icSkSEntity,skill))
//                {
//                    system.Execute(icSkSEntity,skill);
//                }
//            }
//        }
//
////        public void RemoveSkill(IEntity entity, ISkillDataComponent skill)
////        {
////        }
//
//        public ISkillManager AddSkillSystem(ISkillExecuteSystem skillSystem)
//        {
//            _skillSystem.Add(skillSystem);
//            return this;
//        }
//    }
//}