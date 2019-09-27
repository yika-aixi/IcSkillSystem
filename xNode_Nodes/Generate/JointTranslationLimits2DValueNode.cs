using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointTranslationLimits2D Value")]
    public partial class JointTranslationLimits2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.JointTranslationLimits2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.JointTranslationLimits2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}