using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeRefreshMode Value")]
    public partial class ReflectionProbeRefreshModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeRefreshMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeRefreshMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}