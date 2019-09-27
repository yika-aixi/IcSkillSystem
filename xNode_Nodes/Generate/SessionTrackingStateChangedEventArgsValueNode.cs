using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/SessionTrackingStateChangedEventArgs Value")]
    public partial class SessionTrackingStateChangedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.SessionTrackingStateChangedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.SessionTrackingStateChangedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}