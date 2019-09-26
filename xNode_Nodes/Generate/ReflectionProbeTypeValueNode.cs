using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeType Value")]
    public partial class ReflectionProbeTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}