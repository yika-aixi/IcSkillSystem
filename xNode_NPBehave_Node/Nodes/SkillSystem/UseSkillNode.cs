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
using Action = System.Action;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.SkillSystems
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Skill/Use")]
    public class UseSkillNode:ANPNode<Action>,IEntityKey
    {
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private ISkillManager _skillManager;
        
        [Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited)]
        private Blackboard _blackboard;

        [SerializeField]
        private string _entityKey = BlackBoardConstKeyTables.UseSkillEntity;
        
        [SerializeField]
        private string _skillComponentAQName;

        private ISkillDataComponent _skill;

        public string EntityKey { get; } = nameof(_entityKey);
        protected override Action GetOutValue()
        {
            _skillManager = GetInputValue(nameof(_skillManager), _skillManager);
            _blackboard = GetInputValue(nameof(_blackboard), _blackboard);
            
            var skillType = Type.GetType(_skillComponentAQName);

            if (skillType == null)
            {
                return null;
            }
            
            _skill = (ISkillDataComponent)Activator.CreateInstance(skillType);

            foreach (var dynamicInput in DynamicInputs)
            {
                var value = dynamicInput.GetInputValue();

                if (value == null)
                {
                    Debug.LogWarning($"{dynamicInput?.fieldName} 失败 Value 没有连接,跳过");
                    continue;
                }
                
                try
                {
                    var field = skillType.GetField(dynamicInput.fieldName);
                    if (field != null)
                    {
                        field.SetValue(_skill, value);
                        continue;
                    }
                    
                    var property = skillType.GetProperty(dynamicInput.fieldName);
                    
                    property.SetValue(_skill,value);
                }
                catch(SystemException e)
                {
                    Debug.LogError($"{dynamicInput?.fieldName} 失败 Value: {value}\n{e}");
                }    
            }

            return _execute;
        }
        
        private void _execute()
        {
            var entity = _blackboard.Get<IEntity>(_entityKey);
            
            _skillManager.UseSkill(entity,_skill);
        }
    }
}