using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointLimitState2D Value")]
    public partial class JointLimitState2DValueNode:ValueNode<ValueInfo<UnityEngine.JointLimitState2D>>
    {
        [SerializeField]
        private UnityEngine.JointLimitState2D _value;
   
        private ValueInfo<UnityEngine.JointLimitState2D> _variableValue = new ValueInfo<UnityEngine.JointLimitState2D>();
   
        protected override ValueInfo<UnityEngine.JointLimitState2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}