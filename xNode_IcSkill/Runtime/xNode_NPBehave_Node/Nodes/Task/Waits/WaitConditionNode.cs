using CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds Condition")]
    public class WaitConditionNode:AConditionNode
    {

        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)]
        private float _waitTime;

        private bool _init = false;
        private float _currentTime;
        protected override bool Condition()
        {
            if (!_init)
            {
                _init = true;
                _currentTime = GetInputValue(nameof(_waitTime), _waitTime);
            }
            
            _currentTime -= Time.fixedDeltaTime;
            
            if (_currentTime <= 0)
            {
                _init = false;
                return true;
            }

            return false;
        }
    }
}