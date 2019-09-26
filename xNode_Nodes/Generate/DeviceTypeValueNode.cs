using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DeviceType Value")]
    public partial class DeviceTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.DeviceType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.DeviceType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}