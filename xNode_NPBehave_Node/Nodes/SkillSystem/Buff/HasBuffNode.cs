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
                
                return BuffManager.HasBuff(Target, BuffType, _hasBuff());
            };
        }

        private IBuffDataComponent _hasBuff()
        {
            //todo 暂时先这样写下
            Debug.LogError("空值比较 -----------");
            return (IBuffDataComponent) Activator.CreateInstance(BuffType);
        }
    }
}