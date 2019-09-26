using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/AimConstraint Value")]
    public partial class AimConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.AimConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.AimConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}