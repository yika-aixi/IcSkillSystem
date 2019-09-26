using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/GameCenterModule/UserState Value")]
    public partial class UserStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SocialPlatforms.UserState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SocialPlatforms.UserState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}