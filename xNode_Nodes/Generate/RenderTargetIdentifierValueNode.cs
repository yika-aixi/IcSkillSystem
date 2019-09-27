using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTargetIdentifier Value")]
    public partial class RenderTargetIdentifierValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderTargetIdentifier _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderTargetIdentifier);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}