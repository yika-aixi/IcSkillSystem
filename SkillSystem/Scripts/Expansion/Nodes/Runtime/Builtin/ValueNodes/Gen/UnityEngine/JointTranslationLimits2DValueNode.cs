using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointTranslationLimits2D Value")]
    public partial class JointTranslationLimits2DValueNode:ValueNode<IcVariableJointTranslationLimits2D>
    {
        [SerializeField]
        private UnityEngine.JointTranslationLimits2D _value;
   
        private IcVariableJointTranslationLimits2D _variableValue = new IcVariableJointTranslationLimits2D();
   
        protected override IcVariableJointTranslationLimits2D GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}