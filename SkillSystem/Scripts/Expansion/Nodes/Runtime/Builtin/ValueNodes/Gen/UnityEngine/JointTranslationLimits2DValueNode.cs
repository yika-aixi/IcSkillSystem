using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointTranslationLimits2D Value")]
    public partial class JointTranslationLimits2DValueNode:ValueNode<ValueInfo<UnityEngine.JointTranslationLimits2D>>
    {
        [SerializeField]
        private UnityEngine.JointTranslationLimits2D _value;
   
        private ValueInfo<UnityEngine.JointTranslationLimits2D> _variableValue = new ValueInfo<UnityEngine.JointTranslationLimits2D>();
   
        protected override ValueInfo<UnityEngine.JointTranslationLimits2D> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}