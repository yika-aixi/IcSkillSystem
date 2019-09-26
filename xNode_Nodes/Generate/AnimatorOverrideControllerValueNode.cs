using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorOverrideController Value")]
    public partial class AnimatorOverrideControllerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorOverrideController _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorOverrideController);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}