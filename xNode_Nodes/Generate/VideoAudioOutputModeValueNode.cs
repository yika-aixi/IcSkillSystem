using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoAudioOutputMode Value")]
    public partial class VideoAudioOutputModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoAudioOutputMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoAudioOutputMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}