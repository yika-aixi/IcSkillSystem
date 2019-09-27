using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/GameCenterModule/UserScope Value")]
    public partial class UserScopeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SocialPlatforms.UserScope _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SocialPlatforms.UserScope);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}