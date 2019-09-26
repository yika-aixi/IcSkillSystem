using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConfigurableJoint Value")]
    public partial class ConfigurableJointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ConfigurableJoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ConfigurableJoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}