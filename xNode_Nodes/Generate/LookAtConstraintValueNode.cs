using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/LookAtConstraint Value")]
    public partial class LookAtConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.LookAtConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.LookAtConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}