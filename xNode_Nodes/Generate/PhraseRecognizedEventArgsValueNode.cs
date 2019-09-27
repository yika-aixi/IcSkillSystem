using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PhraseRecognizedEventArgs Value")]
    public partial class PhraseRecognizedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.PhraseRecognizedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.PhraseRecognizedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}