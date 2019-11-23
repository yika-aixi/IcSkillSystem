using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Builtin.Component
{
    public class SelfBlackBoardComponent:MonoBehaviour
    {
        public Blackboard Blackboard { get; private set; }

        public bool UseUnityContextClock = true;
        
        public void Init()
        {
            if (!UseUnityContextClock)
            {
                _clock = new Clock();
            }
            Blackboard = new Blackboard(UseUnityContextClock ? UnityContext.GetClock() : _clock);
        }
        
        private Clock _clock;

        void Update()
        {
            _clock?.Update(Time.deltaTime);
        }
    }
}