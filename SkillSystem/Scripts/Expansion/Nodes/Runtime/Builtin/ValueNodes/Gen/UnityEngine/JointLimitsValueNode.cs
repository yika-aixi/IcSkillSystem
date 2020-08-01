using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/JointLimits Value")]
    public partial class JointLimitsValueNode:ValueNode<IcVariableJointLimits>
    {
        [SerializeField]
        private UnityEngine.JointLimits _value;
   
        private IcVariableJointLimits _variableValue = new IcVariableJointLimits();
   
        protected override IcVariableJointLimits GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}