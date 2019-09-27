using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationStream Value")]
    public partial class AnimationStreamValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.AnimationStream _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.AnimationStream);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}