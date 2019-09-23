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
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Use")]
    public class UseSkillNode:ANPBehaveNode,IActionExecuteNode,IOutPutName,IEntityKey
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private GetBlackboardValue _skillManagerValue;

        [SerializeField]
        private string _entityKey = BlackBoardConstKeyTables.UseSkillEntity;
        
        [SerializeField]
        private string _skillComponentAQName;
        
        [SerializeField,Output()]
        private UseSkillNode _output;

        private ISkillManager _skillManager;
        private ISkillDataComponent _skill;
        private Blackboard _blackboard;

        protected override void CreateNode()
        {
            _output = this;

            var getBlackboardValue = GetInputValue(nameof(_skillManagerValue), _skillManagerValue);
            _blackboard = getBlackboardValue.Blackboard;
            
            _skillManager = (ISkillManager) getBlackboardValue.Value;

            var skillType = Type.GetType(_skillComponentAQName);

            if (skillType == null)
            {
                return;
            }
            
            _skill = (ISkillDataComponent)Activator.CreateInstance(skillType);

            foreach (var dynamicInput in DynamicInputs)
            {
                //todo 效率可能不是很好
                ValueNode valueNode = dynamicInput.GetInputValue() as ValueNode;
                
                if (valueNode)
                {
                    skillType.GetField(dynamicInput.fieldName).SetValue(_skill,valueNode.Value);    
                }
            }
        }

        public void Execute()
        {
            if (_skillManager == null || _skill == null)
            {
                return;
            }
            
            var entity = _blackboard.Get<IEntity>(_entityKey);
            
            _skillManager.UseSkill(entity,_skill);
        }

        public string OutPutName { get; } = nameof(_output);
        public string EntityKey { get; } = nameof(_entityKey);
    }
}