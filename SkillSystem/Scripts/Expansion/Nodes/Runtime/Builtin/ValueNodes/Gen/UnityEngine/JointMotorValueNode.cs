using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointMotor Value")]
    public partial class JointMotorValueNode:ValueNode<ValueInfo<UnityEngine.JointMotor>>
    {
        [SerializeField]
        private UnityEngine.JointMotor _value;
   
        private ValueInfo<UnityEngine.JointMotor> _variableValue;
   
        protected override ValueInfo<UnityEngine.JointMotor> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}