using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/HingeJoint Value")]
    public partial class HingeJointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.HingeJoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.HingeJoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}