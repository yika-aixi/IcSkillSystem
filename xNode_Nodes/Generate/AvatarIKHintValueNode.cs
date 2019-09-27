using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AvatarIKHint Value")]
    public partial class AvatarIKHintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AvatarIKHint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AvatarIKHint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}