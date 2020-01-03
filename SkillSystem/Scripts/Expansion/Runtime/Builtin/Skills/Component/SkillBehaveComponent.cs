//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月15日-16:59
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using CabinIcarus.IcSkillSystem.xNode_Group;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Builtin.Skills.Component
{
    /// <summary>
    /// 技能行为
    /// </summary>
    public class SkillBehaveComponent : MonoBehaviour
    {
        public IcSkillGroup Group;
        
        public bool Passive;

        protected IcSkillGroup CurrentSkill;

        public ValueSDict Data;

        private List<IcSkillGroup> _skillGroups = new List<IcSkillGroup>();
        
        private void Awake()
        {
            _init();
        }

        protected virtual void OnEnable()
        {
            if (Passive)
            {
                Use(Data);
            }
        }

        protected virtual void OnDisable()
        {
            foreach (var skillGroup in _skillGroups)
            {
                if (skillGroup.RootNode.IsActive)
                {
                    skillGroup.RootNode.Stop();
                }
            }
        }

        private void _init()
        {
            CurrentSkill = CreateSkill();
            CurrentSkill.Start();
            Init();
        }

        protected IcSkillGroup CreateSkill()
        {
            IcSkillGroup skillGroup = (IcSkillGroup) Group.Copy();
            skillGroup.Owner = gameObject;
            _skillGroups.Add(skillGroup);
            return skillGroup;
        }

        private void _debug(Root root)
        {
#if UNITY_EDITOR
            Debugger debugger = null;
            
            if (!debugger)
            {
                debugger = gameObject.AddComponent<Debugger>();
            }

            debugger.BehaviorTree = root;
#endif
        }

        protected virtual void Init()
        {
        }

        public void Use()
        {
            Use(Data);
        }

        public virtual void Use(Dictionary<string, object> data)
        {
            if (CurrentSkill.RootNode.IsActive)
            {
                foreach (var skill in _skillGroups)
                {
                    if (!skill.RootNode.IsActive)
                    {
                        CurrentSkill = skill;
                        break;
                    }
                }

                if (CurrentSkill.RootNode.IsActive)
                {
                    CurrentSkill = CreateSkill();
                    CurrentSkill.Start();
                }
            }

            CurrentSkill.SetBlackboardVariable(data);
            _debug(CurrentSkill.RootNode);
            CurrentSkill.RootNode.Start();
        }

        public void Stop()
        {
            CurrentSkill.RootNode.Stop();
        }

        #region Test

        [ContextMenu("ReLoad Group")]
        void _reload()
        {
            _init();
        }

        [ContextMenu("Use")]
        void _use()
        {
            Use();
        }

        #endregion
    }
}