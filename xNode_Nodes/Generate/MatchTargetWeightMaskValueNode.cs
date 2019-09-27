using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/MatchTargetWeightMask Value")]
    public partial class MatchTargetWeightMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MatchTargetWeightMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MatchTargetWeightMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}