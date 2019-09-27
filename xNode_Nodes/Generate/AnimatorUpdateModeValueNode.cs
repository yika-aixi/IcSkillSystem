using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorUpdateMode Value")]
    public partial class AnimatorUpdateModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorUpdateMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorUpdateMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}