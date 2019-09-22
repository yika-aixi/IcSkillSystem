using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Condition")]
    public class SkillConditionNode:NeedBlackboardAnpBehaveNode,IFuncExecuteNode<bool>,IOutPutName
    {
        [SerializeField,Output()]
        private SkillConditionNode _output;
        
        [SerializeField]
        private string _conditionAQName;

        private ACondition _condition;

        protected override void CreateNode()
        {
            base.CreateNode();
            
            _output = this;
            
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

        public string OutPutName { get; } = nameof(_output);
    }
}