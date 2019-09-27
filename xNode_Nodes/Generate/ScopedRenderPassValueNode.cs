using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScopedRenderPass Value")]
    public partial class ScopedRenderPassValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ScopedRenderPass _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ScopedRenderPass);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}