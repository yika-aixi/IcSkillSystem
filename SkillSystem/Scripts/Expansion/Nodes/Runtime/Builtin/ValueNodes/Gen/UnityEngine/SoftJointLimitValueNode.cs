using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SoftJointLimit Value")]
    public partial class SoftJointLimitValueNode:ValueNode<IcVariableSoftJointLimit>
    {
        [SerializeField]
        private UnityEngine.SoftJointLimit _value;
   
        private IcVariableSoftJointLimit _variableValue = new IcVariableSoftJointLimit();
   
        protected override IcVariableSoftJointLimit GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}