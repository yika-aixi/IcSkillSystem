using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderBuffer Value")]
    public partial class RenderBufferValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderBuffer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderBuffer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}