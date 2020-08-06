using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointLimits Value")]
    public partial class JointLimitsValueNode:ValueNode<ValueInfo<UnityEngine.JointLimits>>
    {
        [SerializeField]
        private UnityEngine.JointLimits _value;
   
        private ValueInfo<UnityEngine.JointLimits> _variableValue = new ValueInfo<UnityEngine.JointLimits>();
   
        protected override ValueInfo<UnityEngine.JointLimits> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}