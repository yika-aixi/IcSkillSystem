using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraHDRMode Value")]
    public partial class CameraHDRModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CameraHDRMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CameraHDRMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}