using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointDrive Value")]
    public partial class JointDriveValueNode:ValueNode<IcVariableJointDrive>
    {
        [SerializeField]
        private UnityEngine.JointDrive _value;
   
        private IcVariableJointDrive _variableValue = new IcVariableJointDrive();
   
        protected override IcVariableJointDrive GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}