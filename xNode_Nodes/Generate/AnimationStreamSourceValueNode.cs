using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationStreamSource Value")]
    public partial class AnimationStreamSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.AnimationStreamSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.AnimationStreamSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}