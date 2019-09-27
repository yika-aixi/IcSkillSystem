using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTargetBinding Value")]
    public partial class RenderTargetBindingValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderTargetBinding _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderTargetBinding);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}