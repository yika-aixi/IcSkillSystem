using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/UVChannelFlags Value")]
    public partial class UVChannelFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.UVChannelFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.UVChannelFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}