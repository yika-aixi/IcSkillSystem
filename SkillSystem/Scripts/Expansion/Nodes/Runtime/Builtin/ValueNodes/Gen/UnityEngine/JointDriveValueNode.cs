using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointDrive Value")]
    public partial class JointDriveValueNode:ValueNode<ValueInfo<UnityEngine.JointDrive>>
    {
        [SerializeField]
        private UnityEngine.JointDrive _value;
   
        private ValueInfo<UnityEngine.JointDrive> _variableValue = new ValueInfo<UnityEngine.JointDrive>();
   
        protected override ValueInfo<UnityEngine.JointDrive> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}