using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GradientMode Value")]
    public partial class GradientModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GradientMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GradientMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}