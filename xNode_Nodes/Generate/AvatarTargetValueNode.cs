using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AvatarTarget Value")]
    public partial class AvatarTargetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AvatarTarget _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AvatarTarget);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}