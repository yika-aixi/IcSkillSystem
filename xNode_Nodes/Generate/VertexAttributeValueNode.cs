using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/VertexAttribute Value")]
    public partial class VertexAttributeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.VertexAttribute _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.VertexAttribute);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}