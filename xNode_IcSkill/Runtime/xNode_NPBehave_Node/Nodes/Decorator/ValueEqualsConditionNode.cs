using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Decorator
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Decorator/Value Equals Or NoEquals Condition")]
    public class ValueEqualsConditionNode:AConditionNode
    {
        [SerializeField]
        private bool _equals;

        [Input(ShowBackingValue.Always,ConnectionType.Override)]
        private object _aValue;
        
        [Input(ShowBackingValue.Always,ConnectionType.Override)]
        private object _bValue;

        protected override bool Condition()
        {
            var aValue = GetInputValue(nameof(_aValue), _aValue);
            var bValue = GetInputValue(nameof(_bValue), _bValue);

            if (_equals)
            {
                return aValue.Equals(bValue);
            }

            return !aValue.Equals(bValue);
        }
    }
}