using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointSpring Value")]
    public partial class JointSpringValueNode:ValueNode<IcVariableJointSpring>
    {
        [SerializeField]
        private UnityEngine.JointSpring _value;
   
        private IcVariableJointSpring _variableValue = new IcVariableJointSpring();
   
        protected override IcVariableJointSpring GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}