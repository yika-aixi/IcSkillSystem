using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DictationCompletionCause Value")]
    public partial class DictationCompletionCauseValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.DictationCompletionCause _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.DictationCompletionCause);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}