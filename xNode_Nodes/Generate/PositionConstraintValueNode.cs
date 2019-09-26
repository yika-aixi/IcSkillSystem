using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/PositionConstraint Value")]
    public partial class PositionConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.PositionConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.PositionConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}