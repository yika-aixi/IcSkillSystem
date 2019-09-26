using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/FixedJoint Value")]
    public partial class FixedJointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FixedJoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FixedJoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}