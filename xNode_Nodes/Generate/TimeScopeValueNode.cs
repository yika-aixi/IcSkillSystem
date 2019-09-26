using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/GameCenterModule/TimeScope Value")]
    public partial class TimeScopeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SocialPlatforms.TimeScope _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SocialPlatforms.TimeScope);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}