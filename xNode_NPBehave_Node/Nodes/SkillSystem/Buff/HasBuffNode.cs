using System;
using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems.Buff
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Buff/Has")]
    public class HasBuffNode:ABuffNode<Func<bool>>
    {
        protected override Func<bool> Execute()
        {
            return () =>
            {
                if (!DynamicInputs.Any())
                {
                    return BuffManager.HasBuff(Target, BuffType);
                }
                
                return BuffManager.HasBuff(Target, BuffType, _hasBuff);
            };
        }

        private bool _hasBuff(IBuffDataComponent x)
        {
            if (!BuffType.IsInstanceOfType(x))
            {
                return false;
            }
            
            var xBuffType = x.GetType();

            foreach (var input in DynamicInputs)
            {
                var inputValue = GetInputValue<object>(input.fieldName);

                var field = xBuffType.GetField(input.fieldName);

                if (field != null)
                {
                    var value = field.GetValue(x);
                    if (value != inputValue)
                    {
                        return false;
                    }
                }

                var property = xBuffType.GetProperty(input.fieldName);

                if (property != null)
                {
                    var value = property.GetValue(x);
                    if (value != inputValue)
                    {
                        return false;
                    }
                }
            }
            Debug.LogError("存在");
            return true;
        }
    }
}