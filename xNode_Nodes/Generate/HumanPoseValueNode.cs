using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/HumanPose Value")]
    public partial class HumanPoseValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HumanPose _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HumanPose);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}