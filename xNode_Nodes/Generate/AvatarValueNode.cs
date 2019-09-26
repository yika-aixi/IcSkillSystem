using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/Avatar Value")]
    public partial class AvatarValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Avatar _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Avatar);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}