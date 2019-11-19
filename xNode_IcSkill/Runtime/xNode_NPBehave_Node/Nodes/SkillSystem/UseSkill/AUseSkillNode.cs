//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月25日-20:58
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Manager;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using SkillSystem.xNode_NPBehave_Node.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    public abstract class AUseSkillNode<T>:ANPNode<T> where T : Delegate
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        protected ISkillManager SkillManager;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("目标")]
        protected IIcSkSEntity Target;

        [SerializeField]
        private string _skillComponentAQName;

        protected ISkillDataComponent Skill;

        protected sealed override T GetOutValue()
        {
            SkillManager = GetInputValue(nameof(SkillManager), SkillManager);
            Target = GetInputValue(nameof(Target), Target);
            
            var skillType = Type.GetType(_skillComponentAQName);

            if (skillType == null)
            {
                return default;
            }
            
            Skill = (ISkillDataComponent) this.DynamicInputCreateInstance(skillType);

            return UseSkill();
        }

        protected abstract T UseSkill();
    }
}