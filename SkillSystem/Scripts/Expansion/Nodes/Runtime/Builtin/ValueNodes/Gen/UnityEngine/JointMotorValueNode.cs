using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointMotor Value")]
    public partial class JointMotorValueNode:ValueNode<IcVariableJointMotor>
    {
        [SerializeField]
        private UnityEngine.JointMotor _value;
   
        private IcVariableJointMotor _variableValue = new IcVariableJointMotor();
   
        protected override IcVariableJointMotor GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}