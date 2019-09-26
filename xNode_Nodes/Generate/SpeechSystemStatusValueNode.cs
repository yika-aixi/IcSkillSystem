using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpeechSystemStatus Value")]
    public partial class SpeechSystemStatusValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.SpeechSystemStatus _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.SpeechSystemStatus);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}