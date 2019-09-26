using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CapturePixelFormat Value")]
    public partial class CapturePixelFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.WebCam.CapturePixelFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.WebCam.CapturePixelFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}