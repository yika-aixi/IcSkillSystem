using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointMotor Value")]
    public partial class JointMotorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointMotor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointMotor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}