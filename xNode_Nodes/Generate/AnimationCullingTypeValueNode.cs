using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationCullingType Value")]
    public partial class AnimationCullingTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimationCullingType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimationCullingType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}