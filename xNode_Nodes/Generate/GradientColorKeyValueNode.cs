using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GradientColorKey Value")]
    public partial class GradientColorKeyValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GradientColorKey _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GradientColorKey);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}