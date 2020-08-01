using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointProjectionMode Value")]
    public partial class JointProjectionModeValueNode:ValueNode<IcVariableJointProjectionMode>
    {
        [SerializeField]
        private UnityEngine.JointProjectionMode _value;
   
        private IcVariableJointProjectionMode _variableValue = new IcVariableJointProjectionMode();
   
        protected override IcVariableJointProjectionMode GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}