using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CameraEvent Value")]
    public partial class CameraEventValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CameraEvent _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CameraEvent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}