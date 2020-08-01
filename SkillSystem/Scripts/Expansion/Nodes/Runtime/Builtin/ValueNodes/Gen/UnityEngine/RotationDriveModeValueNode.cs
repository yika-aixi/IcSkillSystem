using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RotationDriveMode Value")]
    public partial class RotationDriveModeValueNode:ValueNode<IcVariableRotationDriveMode>
    {
        [SerializeField]
        private UnityEngine.RotationDriveMode _value;
   
        private IcVariableRotationDriveMode _variableValue = new IcVariableRotationDriveMode();
   
        protected override IcVariableRotationDriveMode GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}