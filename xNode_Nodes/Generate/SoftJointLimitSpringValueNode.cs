using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SoftJointLimitSpring Value")]
    public partial class SoftJointLimitSpringValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SoftJointLimitSpring _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SoftJointLimitSpring);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}