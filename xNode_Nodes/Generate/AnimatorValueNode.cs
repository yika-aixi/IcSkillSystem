using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/Animator Value")]
    public partial class AnimatorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animator _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animator);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}