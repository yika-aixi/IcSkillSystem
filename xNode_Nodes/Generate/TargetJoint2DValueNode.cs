using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/TargetJoint2D Value")]
    public partial class TargetJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TargetJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TargetJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}