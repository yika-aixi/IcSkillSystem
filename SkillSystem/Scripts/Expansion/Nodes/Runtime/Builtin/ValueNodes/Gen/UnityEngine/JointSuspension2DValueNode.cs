using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointSuspension2D Value")]
    public partial class JointSuspension2DValueNode:ValueNode<IcVariableJointSuspension2D>
    {
        [SerializeField]
        private UnityEngine.JointSuspension2D _value;
   
        private IcVariableJointSuspension2D _variableValue = new IcVariableJointSuspension2D();
   
        protected override IcVariableJointSuspension2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}