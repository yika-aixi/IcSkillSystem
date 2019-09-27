using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpeechError Value")]
    public partial class SpeechErrorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.SpeechError _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.SpeechError);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}