using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/ConstraintSource Value")]
    public partial class ConstraintSourceValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.ConstraintSource _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.ConstraintSource);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}