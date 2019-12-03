//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月25日-20:58
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Utils;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Manager;
using UnityEngine;
using Action = NPBehave.Action;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems
{
    public abstract class AUseSkillNode:ANPNode<Action>
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        protected ISkillManager SkillManager;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("目标")]
        protected IIcSkSEntity Target;

        [SerializeField]
        private string _skillComponentAQName;

        protected ISkillDataComponent Skill;

        protected sealed override Action GetOutValue()
        {
            return new Action(_use);
        }

        private void _use()
        {
            SkillManager = GetInputValue(nameof(SkillManager), SkillManager);
            Target = GetInputValue(nameof(Target), Target);
            
            var skillType = Type.GetType(_skillComponentAQName);

            if (skillType == null)
            {
                return;
            }
            
            Skill = (ISkillDataComponent) this.DynamicInputCreateInstance(skillType);
        }

        protected abstract void UseSkill();
    }
}