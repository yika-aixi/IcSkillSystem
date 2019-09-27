using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/SkeletonBone Value")]
    public partial class SkeletonBoneValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SkeletonBone _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SkeletonBone);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}