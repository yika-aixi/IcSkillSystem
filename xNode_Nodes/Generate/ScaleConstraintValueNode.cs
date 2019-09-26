using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/ScaleConstraint Value")]
    public partial class ScaleConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.ScaleConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.ScaleConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}