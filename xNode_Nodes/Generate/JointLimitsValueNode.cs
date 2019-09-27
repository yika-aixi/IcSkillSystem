using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointLimits Value")]
    public partial class JointLimitsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointLimits _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointLimits);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}