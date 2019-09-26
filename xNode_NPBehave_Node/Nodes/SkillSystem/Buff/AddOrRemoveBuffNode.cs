using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems.Buff
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Buff/Add or Remove")]
    public class AddOrRemoveBuffNode:ABuffNode<Action>
    {
        [SerializeField]
        private bool _isAddBuff = true;
        protected override Action Execute()
        {
            if (_isAddBuff)
            {
                return () => BuffManager.AddBuff(Target, Buff);
            }
            
            return () => BuffManager.RemoveBuff(Target,Buff);
        }
    }
}