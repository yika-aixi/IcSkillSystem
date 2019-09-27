using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraParameters Value")]
    public partial class CameraParametersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.WebCam.CameraParameters _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.WebCam.CameraParameters);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}