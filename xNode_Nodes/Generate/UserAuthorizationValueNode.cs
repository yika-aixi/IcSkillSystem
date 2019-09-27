using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/UserAuthorization Value")]
    public partial class UserAuthorizationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UserAuthorization _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UserAuthorization);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}