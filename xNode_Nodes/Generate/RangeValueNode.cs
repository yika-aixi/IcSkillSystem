using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/GameCenterModule/Range Value")]
    public partial class RangeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SocialPlatforms.Range _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SocialPlatforms.Range);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}