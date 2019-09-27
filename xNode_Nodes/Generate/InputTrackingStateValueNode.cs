using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/InputTrackingState Value")]
    public partial class InputTrackingStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.InputTrackingState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.InputTrackingState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}