using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GradientAlphaKey Value")]
    public partial class GradientAlphaKeyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GradientAlphaKey _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GradientAlphaKey);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}