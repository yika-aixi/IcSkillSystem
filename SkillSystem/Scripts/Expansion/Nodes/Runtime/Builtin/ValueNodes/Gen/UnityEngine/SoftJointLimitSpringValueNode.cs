using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SoftJointLimitSpring Value")]
    public partial class SoftJointLimitSpringValueNode:ValueNode<ValueInfo<UnityEngine.SoftJointLimitSpring>>
    {
        [SerializeField]
        private UnityEngine.SoftJointLimitSpring _value;
   
        private ValueInfo<UnityEngine.SoftJointLimitSpring> _variableValue;
   
        protected override ValueInfo<UnityEngine.SoftJointLimitSpring> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}