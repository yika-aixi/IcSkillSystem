using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorRecorderMode Value")]
    public partial class AnimatorRecorderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorRecorderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorRecorderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}