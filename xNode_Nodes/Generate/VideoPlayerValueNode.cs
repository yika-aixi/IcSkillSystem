using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoPlayer Value")]
    public partial class VideoPlayerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoPlayer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoPlayer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}