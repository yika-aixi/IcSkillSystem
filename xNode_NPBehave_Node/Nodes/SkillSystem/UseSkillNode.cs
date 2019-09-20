//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-23:12
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Components;
using CabinIcarus.IcSkillSystem.Runtime.Skills.Manager;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Use")]
    public class UseSkillNode:NeedBlackboardNPBehaveNode,IActionExecuteNode
    {
        [SerializeField]
        private string _skillComponentAQName;

        [SerializeField,Output()]
        private UseSkillNode _skillNode;

        private ISkillManager _skillManager;
        private ISkillDataComponent _skill;

        public override object GetValue(NodePort port)
        {
            _skillNode = (UseSkillNode) base.GetValue(port);

            return _skillNode;
        }

        protected override void CreateNode()
        {
            if (Blackboard == null)
            {
                return;
            }
            
            _skillManager = Blackboard.Get<ISkillManager>(BlackBoardConstKeyTables.SkillManager);

            var skillType = Type.GetType(_skillComponentAQName);
            
            _skill = (ISkillDataComponent)Activator.CreateInstance(skillType);

            foreach (var dynamicInput in DynamicInputs)
            {
                //todo 效率可能不是很好
                var value = dynamicInput.GetInputValue();
                
                skillType.GetField(dynamicInput.fieldName).SetValue(_skill,value);
            }
            
        }

        public void Execute()
        {
            if (_skillManager == null)
            {
                return;
            }
            
            var entity = Blackboard.Get<IEntity>(BlackBoardConstKeyTables.UseSkillEntity);
            
            _skillManager.UseSkill(entity,_skill);
        }
    }
}