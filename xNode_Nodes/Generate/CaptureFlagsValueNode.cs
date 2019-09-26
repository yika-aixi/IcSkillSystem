using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CaptureFlags Value")]
    public partial class CaptureFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Profiling.Memory.Experimental.CaptureFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Profiling.Memory.Experimental.CaptureFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}