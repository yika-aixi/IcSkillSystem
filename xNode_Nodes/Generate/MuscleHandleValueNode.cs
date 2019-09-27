using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/MuscleHandle Value")]
    public partial class MuscleHandleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Animations.MuscleHandle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Animations.MuscleHandle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}