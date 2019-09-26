using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionCubemapCompression Value")]
    public partial class ReflectionCubemapCompressionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionCubemapCompression _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionCubemapCompression);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}