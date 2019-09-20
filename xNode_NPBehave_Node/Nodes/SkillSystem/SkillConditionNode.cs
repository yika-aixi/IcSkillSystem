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
        
        [SerializeField,Output()]
        private SkillConditionNode _conditionNode;

        private ACondition _condition;

        public override object GetValue(NodePort port)
        {
            _conditionNode = (SkillConditionNode) base.GetValue(port);
            return _conditionNode;
        }

        protected override void CreateNode()
        {
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