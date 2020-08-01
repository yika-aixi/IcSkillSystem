using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointLimitState2D Value")]
    public partial class JointLimitState2DValueNode:ValueNode<IcVariableJointLimitState2D>
    {
        [SerializeField]
        private UnityEngine.JointLimitState2D _value;
   
        private IcVariableJointLimitState2D _variableValue = new IcVariableJointLimitState2D();
   
        protected override IcVariableJointLimitState2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}