using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ConfigurableJointMotion Value")]
    public partial class ConfigurableJointMotionValueNode:ValueNode<IcVariableConfigurableJointMotion>
    {
        [SerializeField]
        private UnityEngine.ConfigurableJointMotion _value;
   
        private IcVariableConfigurableJointMotion _variableValue = new IcVariableConfigurableJointMotion();
   
        protected override IcVariableConfigurableJointMotion GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}