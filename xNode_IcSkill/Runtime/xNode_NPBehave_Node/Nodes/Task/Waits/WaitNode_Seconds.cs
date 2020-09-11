using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/Seconds")]
    public class WaitNode_Seconds:ANPBehaveNode<Wait>
    {
        [SerializeField,Input(ShowBackingValue.Always,ConnectionType.Override,TypeConstraint.InheritedInverse)] 
        private ValueInfo<float> _seconds;

        protected override Wait CreateOutValue()
        {
            return new Wait(_getSeconds);
        }

        private float _getSeconds()
        {
            return GetInputValue(nameof(_seconds), _seconds);
        }
    }
}