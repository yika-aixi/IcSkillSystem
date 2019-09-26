using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AvatarIKGoal Value")]
    public partial class AvatarIKGoalValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AvatarIKGoal _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AvatarIKGoal);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}