using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoClipPlayable Value")]
    public partial class VideoClipPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Video.VideoClipPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Video.VideoClipPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}