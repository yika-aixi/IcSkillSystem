using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using SkillSystem.xNode_NPBehave_Node.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems.Buff
{
    
    public abstract class ABuffNode<T>:ANPNode<T> where T : Delegate
    {
        [SerializeField]
        private string _buffAQName;

        [Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Inherited)]
        protected IBuffManager BuffManager;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        [PortTooltip("目标")]
        protected IEntity Target;
        
        protected IBuffDataComponent Buff;
        
        protected sealed override T GetOutValue()
        {
            BuffManager = GetInputValue(nameof(BuffManager), BuffManager);
            Target = GetInputValue(nameof(Target), Target);;

            var buffType = Type.GetType(_buffAQName);

            if (buffType == null)
            {
                return null;
            }
            
            Buff = (IBuffDataComponent) this.DynamicInputCreateInstance(buffType);

            return Execute();
        }

        protected abstract T Execute();
    }
}