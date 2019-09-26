using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoTimeReference Value")]
    public partial class VideoTimeReferenceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoTimeReference _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoTimeReference);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}