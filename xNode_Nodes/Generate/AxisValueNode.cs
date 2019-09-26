using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AnimationModule/Axis Value")]
    public partial class AxisValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Animations.Axis _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Animations.Axis);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}