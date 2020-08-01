using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointAngleLimits2D Value")]
    public partial class JointAngleLimits2DValueNode:ValueNode<IcVariableJointAngleLimits2D>
    {
        [SerializeField]
        private UnityEngine.JointAngleLimits2D _value;
   
        private IcVariableJointAngleLimits2D _variableValue = new IcVariableJointAngleLimits2D();
   
        protected override IcVariableJointAngleLimits2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}