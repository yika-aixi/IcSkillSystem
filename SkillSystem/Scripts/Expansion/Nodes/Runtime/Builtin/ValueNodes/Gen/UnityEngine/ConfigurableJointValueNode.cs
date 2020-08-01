using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConfigurableJoint Value")]
    public partial class ConfigurableJointValueNode:ValueNode<UnityEngine.ConfigurableJoint>
    {
        [SerializeField]
        private UnityEngine.ConfigurableJoint _value;
   
        protected override UnityEngine.ConfigurableJoint GetTValue()
        {
            return _value;
        }
    }
}