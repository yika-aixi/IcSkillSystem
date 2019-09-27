using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationMixerPlayable Value")]
    public partial class AnimationMixerPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.AnimationMixerPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.AnimationMixerPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}