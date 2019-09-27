using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/DurationUnit Value")]
    public partial class DurationUnitValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.DurationUnit _value;

        public override Type ValueType { get; } = typeof(UnityEngine.DurationUnit);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}