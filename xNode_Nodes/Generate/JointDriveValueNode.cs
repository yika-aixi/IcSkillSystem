using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointDrive Value")]
    public partial class JointDriveValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointDrive _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointDrive);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}