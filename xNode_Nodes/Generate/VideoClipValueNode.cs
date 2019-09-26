using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoClip Value")]
    public partial class VideoClipValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoClip _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoClip);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}