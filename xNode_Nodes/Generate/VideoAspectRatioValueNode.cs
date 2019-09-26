using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoAspectRatio Value")]
    public partial class VideoAspectRatioValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoAspectRatio _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoAspectRatio);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}