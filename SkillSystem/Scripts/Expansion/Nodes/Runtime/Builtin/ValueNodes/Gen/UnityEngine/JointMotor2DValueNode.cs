using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointMotor2D Value")]
    public partial class JointMotor2DValueNode:ValueNode<IcVariableJointMotor2D>
    {
        [SerializeField]
        private UnityEngine.JointMotor2D _value;
   
        private IcVariableJointMotor2D _variableValue = new IcVariableJointMotor2D();
   
        protected override IcVariableJointMotor2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}