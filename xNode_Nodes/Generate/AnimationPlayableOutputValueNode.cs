using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationPlayableOutput Value")]
    public partial class AnimationPlayableOutputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.AnimationPlayableOutput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.AnimationPlayableOutput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}