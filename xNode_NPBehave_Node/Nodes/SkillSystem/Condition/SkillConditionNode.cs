using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Condition")]
    public class SkillConditionNode:ANPNode<Func<bool>>,IEntityKey
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private IBuffManager _buffManagerValue;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Blackboard _blackboard;
        
        [SerializeField]
        private string _entityKey = BlackBoardConstKeyTables.UseSkillEntity;
        
        [SerializeField]
        private string _conditionAQName;
        public string EntityKey { get; } = nameof(_entityKey);

        private ACondition _condition;
        
        protected override Func<bool> GetOutValue()
        {
            _buffManagerValue = GetInputValue(nameof(_buffManagerValue), _buffManagerValue);
            _blackboard = GetInputValue(nameof(_blackboard), _blackboard);;

            var conditionType = Type.GetType(_conditionAQName);

            if (conditionType == null)
            {
                return null;
            }
            _condition = (ACondition) Activator.CreateInstance(conditionType,_buffManagerValue);
            return _execute;
        }

        private bool _execute()
        {
            return _condition.Check(_blackboard.Get<IEntity>(_entityKey));
        }
    }
}