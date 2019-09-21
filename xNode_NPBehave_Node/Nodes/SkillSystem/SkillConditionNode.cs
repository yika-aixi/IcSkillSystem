using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Condition")]
    public class SkillConditionNode:NeedBlackboardNPBehaveNode,ISingleFrameFuncExecuteNode
    {
        [SerializeField]
        private string _conditionAQName;

        private ACondition _condition;

        protected override void CreateNode()
        {
            base.CreateNode();
            
            if (Blackboard == null)
            {
                return;
            }
            
            var buffManager = Blackboard.Get<IBuffManager>(BlackBoardConstKeyTables.BuffManager);

            var connditionType = Type.GetType(_conditionAQName);
            
            _condition = (ACondition) Activator.CreateInstance(connditionType,buffManager);
        }

        public bool Execute()
        {
            if (_condition == null)
            {
                return false;
            }
            
            var entity = Blackboard.Get<IEntity>(BlackBoardConstKeyTables.UseSkillEntity);

            return _condition.Check(entity);
        }
    }
}