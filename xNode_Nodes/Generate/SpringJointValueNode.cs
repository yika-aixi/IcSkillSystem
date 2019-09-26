using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SpringJoint Value")]
    public partial class SpringJointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpringJoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpringJoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}