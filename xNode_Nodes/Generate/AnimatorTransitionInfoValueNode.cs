using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorTransitionInfo Value")]
    public partial class AnimatorTransitionInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorTransitionInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorTransitionInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}