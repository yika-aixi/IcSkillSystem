using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimationPlayMode Value")]
    public partial class AnimationPlayModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimationPlayMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimationPlayMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}