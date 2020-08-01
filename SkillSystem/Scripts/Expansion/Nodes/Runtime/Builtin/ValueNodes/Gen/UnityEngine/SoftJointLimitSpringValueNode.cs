using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SoftJointLimitSpring Value")]
    public partial class SoftJointLimitSpringValueNode:ValueNode<IcVariableSoftJointLimitSpring>
    {
        [SerializeField]
        private UnityEngine.SoftJointLimitSpring _value;
   
        private IcVariableSoftJointLimitSpring _variableValue = new IcVariableSoftJointLimitSpring();
   
        protected override IcVariableSoftJointLimitSpring GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}