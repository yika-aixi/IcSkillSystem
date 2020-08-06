using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointProjectionMode Value")]
    public partial class JointProjectionModeValueNode:ValueNode<ValueInfo<UnityEngine.JointProjectionMode>>
    {
        [SerializeField]
        private UnityEngine.JointProjectionMode _value;
   
        private ValueInfo<UnityEngine.JointProjectionMode> _variableValue = new ValueInfo<UnityEngine.JointProjectionMode>();
   
        protected override ValueInfo<UnityEngine.JointProjectionMode> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}