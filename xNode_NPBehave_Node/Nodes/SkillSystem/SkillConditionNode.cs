using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Condition")]
    public class SkillConditionNode:ANPBehaveNode,IFuncExecuteNode<bool>,IOutPutName,IEntityKey
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private GetBlackboardValue _buffManagerValue;
        
        [SerializeField]
        private string _entityKey = BlackBoardConstKeyTables.UseSkillEntity;
        
        [SerializeField,Output()]
        private SkillConditionNode _output;
        
        [SerializeField]
        private string _conditionAQName;

        private ACondition _condition;
        private Blackboard _blackboard;
        protected override void CreateNode()
        {
            _output = this;
            
            var getBlackboardValue = GetInputValue(nameof(_buffManagerValue), _buffManagerValue);
            _blackboard = getBlackboardValue.Blackboard;

            var conditionType = Type.GetType(_conditionAQName);

            if (conditionType == null)
            {
                return;
            }
            
            _condition = (ACondition) Activator.CreateInstance(conditionType,getBlackboardValue.Value);
        }

        public bool Execute()
        {
            if (_condition == null)
            {
                return false;
            }

            var entity = _blackboard.Get<IEntity>(_entityKey);

            return _condition.Check(entity);
        }

        public string OutPutName { get; } = nameof(_output);
        public string EntityKey { get; } = nameof(_entityKey);
    }
}