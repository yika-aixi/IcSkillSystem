using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AvatarMask Value")]
    public partial class AvatarMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AvatarMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AvatarMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}