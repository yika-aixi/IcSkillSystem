using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SoftJointLimit Value")]
    public partial class SoftJointLimitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SoftJointLimit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SoftJointLimit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}