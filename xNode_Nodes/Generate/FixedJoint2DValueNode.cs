using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/FixedJoint2D Value")]
    public partial class FixedJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FixedJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FixedJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}