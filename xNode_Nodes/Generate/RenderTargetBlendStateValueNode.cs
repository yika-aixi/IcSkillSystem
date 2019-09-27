using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTargetBlendState Value")]
    public partial class RenderTargetBlendStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderTargetBlendState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderTargetBlendState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}