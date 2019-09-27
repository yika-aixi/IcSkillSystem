using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/RecognitionStartedEventArgs Value")]
    public partial class RecognitionStartedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.RecognitionStartedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.RecognitionStartedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}