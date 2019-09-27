using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraProperties Value")]
    public partial class CameraPropertiesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CameraProperties _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CameraProperties);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}