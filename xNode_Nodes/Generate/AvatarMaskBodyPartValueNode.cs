using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AvatarMaskBodyPart Value")]
    public partial class AvatarMaskBodyPartValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AvatarMaskBodyPart _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AvatarMaskBodyPart);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}