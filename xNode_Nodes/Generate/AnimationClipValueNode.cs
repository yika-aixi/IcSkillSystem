using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationClip Value")]
    public partial class AnimationClipValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimationClip _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimationClip);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}