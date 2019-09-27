using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorClipInfo Value")]
    public partial class AnimatorClipInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorClipInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorClipInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}