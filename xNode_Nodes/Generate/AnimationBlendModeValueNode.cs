using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationBlendMode Value")]
    public partial class AnimationBlendModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimationBlendMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimationBlendMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}