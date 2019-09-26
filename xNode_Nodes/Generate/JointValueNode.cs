using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Joint Value")]
    public partial class JointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Joint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Joint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}