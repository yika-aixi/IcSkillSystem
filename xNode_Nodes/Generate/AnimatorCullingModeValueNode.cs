using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorCullingMode Value")]
    public partial class AnimatorCullingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorCullingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorCullingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}