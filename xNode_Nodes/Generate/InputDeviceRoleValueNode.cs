using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/XRModule/InputDeviceRole Value")]
    public partial class InputDeviceRoleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.InputDeviceRole _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.InputDeviceRole);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}