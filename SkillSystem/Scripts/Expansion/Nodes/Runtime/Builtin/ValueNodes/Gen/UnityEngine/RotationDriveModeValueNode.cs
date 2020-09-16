using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RotationDriveMode Value")]
    public partial class RotationDriveModeValueNode:ValueNode<ValueInfo<UnityEngine.RotationDriveMode>>
    {
        [SerializeField]
        private UnityEngine.RotationDriveMode _value;
   
        private ValueInfo<UnityEngine.RotationDriveMode> _variableValue;
   
        protected override ValueInfo<UnityEngine.RotationDriveMode> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}