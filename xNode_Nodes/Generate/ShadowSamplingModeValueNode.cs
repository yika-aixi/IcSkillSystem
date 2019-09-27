using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShadowSamplingMode Value")]
    public partial class ShadowSamplingModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShadowSamplingMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShadowSamplingMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}