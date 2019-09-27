using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationClipPlayable Value")]
    public partial class AnimationClipPlayableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.AnimationClipPlayable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.AnimationClipPlayable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}