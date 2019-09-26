using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoRenderMode Value")]
    public partial class VideoRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}