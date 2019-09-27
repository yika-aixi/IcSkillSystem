using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointSpring Value")]
    public partial class JointSpringValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointSpring _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointSpring);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}