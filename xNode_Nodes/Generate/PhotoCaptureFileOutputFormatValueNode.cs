using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PhotoCaptureFileOutputFormat Value")]
    public partial class PhotoCaptureFileOutputFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.WebCam.PhotoCaptureFileOutputFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.WebCam.PhotoCaptureFileOutputFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}