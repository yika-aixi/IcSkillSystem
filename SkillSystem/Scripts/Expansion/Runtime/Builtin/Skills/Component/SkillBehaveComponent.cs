//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年11月15日-16:59
//CabinIcarus.IcSkillSystem.Expansion.Runtime

using CabinIcarus.IcSkillSystem.xNode_Group;
using NPBehave;
using UnityEngine;

namespace SkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Skills.Component
{
    /// <summary>
    /// 技能行为
    /// </summary>
    public class SkillBehaveComponent:MonoBehaviour
    {
        public IcSkillGroup Group;

        private Root _root;
        
        private void Awake()
        {
            Group.Owner = gameObject;
            
            _init();

#if UNITY_EDITOR
            gameObject.AddComponent<Debugger>().BehaviorTree = _root;
#endif
        }

        private void _init()
        {
            _root = Group.Start();
        }

        public void Use()
        {
            _root.Start();
        }

        public void Stop()
        {
            _root.Stop();
        }

        #region Test

        [ContextMenu("ReLoad Group")]
        void _reload()
        {
            _init();
        }
        
        #endregion
    }
}