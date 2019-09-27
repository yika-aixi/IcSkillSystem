using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointProjectionMode Value")]
    public partial class JointProjectionModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointProjectionMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointProjectionMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}