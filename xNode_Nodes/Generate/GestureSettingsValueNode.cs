using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VRModule/GestureSettings Value")]
    public partial class GestureSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.WSA.Input.GestureSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.WSA.Input.GestureSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}