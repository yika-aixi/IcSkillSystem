using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/VideoModule/Video3DLayout Value")]
    public partial class Video3DLayoutValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Video.Video3DLayout _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Video.Video3DLayout);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}