using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/WheelJoint2D Value")]
    public partial class WheelJoint2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WheelJoint2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WheelJoint2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}