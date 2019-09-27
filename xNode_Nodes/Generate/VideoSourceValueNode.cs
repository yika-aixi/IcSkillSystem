using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoSource Value")]
    public partial class VideoSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}