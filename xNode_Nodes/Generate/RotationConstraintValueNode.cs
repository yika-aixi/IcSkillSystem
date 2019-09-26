using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/RotationConstraint Value")]
    public partial class RotationConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.RotationConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.RotationConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}