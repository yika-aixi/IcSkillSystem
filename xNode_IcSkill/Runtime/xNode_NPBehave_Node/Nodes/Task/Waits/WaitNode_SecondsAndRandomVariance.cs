using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds and Variance")]
    [NodeWidth(300)]
    public class WaitNode_SecondsAndRandomVariance:ANPBehaveNode<Wait>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.Strict)] 
        private float _seconds;
        
        [SerializeField] 
        private float _randomVariance;

        protected override Wait GetOutValue()
        {
            return new Wait(_getSeconds(),_randomVariance);
        }
        
        private float _getSeconds()
        {
            return GetInputValue(nameof(_seconds),_seconds);
        }
    }
}