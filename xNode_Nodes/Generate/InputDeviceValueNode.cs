using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/InputDevice Value")]
    public partial class InputDeviceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.InputDevice _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.InputDevice);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}