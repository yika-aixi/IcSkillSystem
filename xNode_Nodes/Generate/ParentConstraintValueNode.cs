using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/ParentConstraint Value")]
    public partial class ParentConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.ParentConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.ParentConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}