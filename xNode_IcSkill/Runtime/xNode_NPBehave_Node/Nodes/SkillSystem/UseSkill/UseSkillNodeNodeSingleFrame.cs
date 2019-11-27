//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-23:12
//Assembly-CSharp

using System;
using UnityEngine;
using Node = XNode.Node;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Use/Single Frame")]
    public class UseSkillNodeNodeSingleFrame:AUseSkillNode<Func<bool>>
    {
        [SerializeField]
        private bool _result = true;
        
        protected override Func<bool> UseSkill()
        {
            return () =>
            {
                SkillManager.UseSkill(Target, Skill);
                return _result;
            };
        }
    }
}