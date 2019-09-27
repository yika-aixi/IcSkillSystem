using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/RecognitionEndedEventArgs Value")]
    public partial class RecognitionEndedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.RecognitionEndedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.RecognitionEndedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}