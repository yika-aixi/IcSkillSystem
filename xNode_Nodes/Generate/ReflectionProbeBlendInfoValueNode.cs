using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeBlendInfo Value")]
    public partial class ReflectionProbeBlendInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeBlendInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeBlendInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}