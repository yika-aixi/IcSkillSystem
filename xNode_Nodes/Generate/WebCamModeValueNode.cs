using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/WebCamMode Value")]
    public partial class WebCamModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.WebCam.WebCamMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.WebCam.WebCamMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}