//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月23日-23:13
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.xNode_Group;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansions
{
    public class SkillManagerCom : MonoBehaviour
    {
        public IcSkillGroup[] Skills;

        public const string UseSkillEntityKey = "UseSkillEntity";
        
        public const string SkillTargetEntityKey = "TargetEntity";

        public BuffEntity SelfEntity;
        
        private void Awake()
        {
        }

        private Blackboard _blackboard;
        
        private void Start()
        {
            _blackboard = UnityContext.GetSharedBlackboard(GameRoot.SharedBlackboardKey);
        }

        public void SetTargetEntity(BuffEntity buffEntity)
        {
            _blackboard.Set(UseSkillEntityKey,SelfEntity);
            _blackboard.Set(SkillTargetEntityKey,buffEntity);
        }

        public void UseSkill(int index)
        {
            if (index >= Skills.Length)
            {
                return;
            }
            
            var bt = Skills[index].Start();
            bt?.Start();
        }
    }
}