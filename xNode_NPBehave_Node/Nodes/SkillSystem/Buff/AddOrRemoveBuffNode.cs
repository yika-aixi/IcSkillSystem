using System;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components;
using CabinIcarus.IcSkillSystem.Expansions;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using SkillSystem.xNode_NPBehave_Node.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems.Buff
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Buff/Add or Remove")]
    public class AddOrRemoveBuffNode:ABuffNode<Action>
    {
        [SerializeField]
        private bool _isAddBuff = true;

        private IBuffDataComponent _buff;
        
        protected override Action Execute()
        {
            if (BuffType == null)
            {
                return null;
            }
            
            _buff = (IBuffDataComponent) this.DynamicInputCreateInstance(BuffType);
            if (_isAddBuff)
            {
                return () => BuffManager.AddBuff(Target, _buff);
            }
            
            return () => BuffManager.RemoveBuff(Target,_buff);
        }
    }
}