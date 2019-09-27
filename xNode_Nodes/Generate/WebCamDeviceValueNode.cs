using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/WebCamDevice Value")]
    public partial class WebCamDeviceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WebCamDevice _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WebCamDevice);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}