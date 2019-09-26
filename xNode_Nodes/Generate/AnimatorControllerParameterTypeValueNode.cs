using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorControllerParameterType Value")]
    public partial class AnimatorControllerParameterTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorControllerParameterType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorControllerParameterType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}