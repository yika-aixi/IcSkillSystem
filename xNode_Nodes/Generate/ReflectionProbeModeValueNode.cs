using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeMode Value")]
    public partial class ReflectionProbeModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}