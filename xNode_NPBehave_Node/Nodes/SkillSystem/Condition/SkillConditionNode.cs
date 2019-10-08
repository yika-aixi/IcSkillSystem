using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using SkillSystem.xNode_NPBehave_Node.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Condition")]
    public class SkillConditionNode:ANPNode<Func<bool>>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private IBuffManager<IBuffDataComponent> _buffManagerValue;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("目标")]
        protected IEntity Target;
        
        [SerializeField]
        private string _conditionAQName;

        private ACondition _condition;
        
        protected override Func<bool> GetOutValue()
        {
            _buffManagerValue = GetInputValue(nameof(_buffManagerValue), _buffManagerValue);
            Target = GetInputValue(nameof(Target), Target);;

            var conditionType = Type.GetType(_conditionAQName);

            if (conditionType == null)
            {
                return null;
            }
            
            _condition = (ACondition) this.DynamicInputCreateInstance(conditionType,_buffManagerValue);
            
            return _execute;
        }

        private bool _execute()
        {
            return _condition.Check(Target);
        }
    }
}