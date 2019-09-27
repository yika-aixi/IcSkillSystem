using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationLayerMixerPlayable Value")]
    public partial class AnimationLayerMixerPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.AnimationLayerMixerPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.AnimationLayerMixerPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}