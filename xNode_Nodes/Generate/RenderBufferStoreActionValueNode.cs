using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderBufferStoreAction Value")]
    public partial class RenderBufferStoreActionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderBufferStoreAction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderBufferStoreAction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}