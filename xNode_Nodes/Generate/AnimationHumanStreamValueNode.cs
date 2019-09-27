using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationHumanStream Value")]
    public partial class AnimationHumanStreamValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.AnimationHumanStream _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.AnimationHumanStream);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}