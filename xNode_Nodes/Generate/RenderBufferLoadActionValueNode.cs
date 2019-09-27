using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderBufferLoadAction Value")]
    public partial class RenderBufferLoadActionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderBufferLoadAction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderBufferLoadAction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}