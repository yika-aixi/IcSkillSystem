using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConfigurableJointMotion Value")]
    public partial class ConfigurableJointMotionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ConfigurableJointMotion _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ConfigurableJointMotion);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}