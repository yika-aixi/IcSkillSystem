using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeTimeSlicingMode Value")]
    public partial class ReflectionProbeTimeSlicingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeTimeSlicingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeTimeSlicingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}