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

            return _equals ? _compare(aValue, bValue) : !_compare(aValue,bValue);
        }

        private bool _compare(object aValue, object bValue)
        {
            if (aValue == null && bValue == null)
            {
                return true;
            }

            if (aValue == null)
            {
                return false;
            }

            return aValue.Equals(bValue);
        }
    }
}