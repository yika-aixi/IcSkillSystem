using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/FrameReceivedEventArgs Value")]
    public partial class FrameReceivedEventArgsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.XR.FrameReceivedEventArgs _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.XR.FrameReceivedEventArgs);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}