using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AnimatorStateInfo Value")]
    public partial class AnimatorStateInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnimatorStateInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnimatorStateInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}