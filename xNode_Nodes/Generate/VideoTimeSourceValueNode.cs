using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/VideoTimeSource Value")]
    public partial class VideoTimeSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.VideoTimeSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.VideoTimeSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}