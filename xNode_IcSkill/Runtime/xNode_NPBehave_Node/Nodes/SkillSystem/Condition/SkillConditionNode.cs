using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Utils;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Condition;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Condition")]
    public class SkillConditionNode:ANPNode<Condition>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private Stops _stops;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private IBuffManager<IIcSkSEntity> _buffManagerValue;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("目标")]
        protected IIcSkSEntity Target;
        
        [SerializeField,Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.Inherited)]
        protected Node DecorateeNode;
        
        [SerializeField]
        private string _conditionAQName;

        private ACondition<IIcSkSEntity> _condition;
        
        protected override Condition GetOutValue()
        {
            return new Condition(_execute,GetInputValue(nameof(_stops),_stops),GetInputValue(nameof(DecorateeNode),DecorateeNode));
        }

        private bool _execute()
        {
            _buffManagerValue = GetInputValue(nameof(_buffManagerValue), _buffManagerValue);
            Target = GetInputValue(nameof(Target), Target);;

            var conditionType = Type.GetType(_conditionAQName);

            if (conditionType == null)
            {
                return false;
            }
            
            _condition = (ACondition<IIcSkSEntity>) this.DynamicInputCreateInstance(conditionType,_buffManagerValue);
            
            return _condition.Check(Target);
        }
    }
}