using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorControllerPlayable Value")]
    public partial class AnimatorControllerPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.AnimatorControllerPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.AnimatorControllerPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}