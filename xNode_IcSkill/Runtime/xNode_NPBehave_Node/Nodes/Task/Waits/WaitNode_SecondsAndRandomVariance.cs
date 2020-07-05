using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds and Variance")]
    [NodeWidth(300)]
    public class WaitNode_SecondsAndRandomVariance:ANPBehaveNode<Wait>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)] 
        private float _seconds;
        
        [SerializeField] 
        private float _randomVariance;

        protected override Wait CreateOutValue()
        {
            return new Wait(_getSeconds(),_randomVariance);
        }
        
        private float _getSeconds()
        {
            return GetInputValue(nameof(_seconds),_seconds);
        }
    }
}