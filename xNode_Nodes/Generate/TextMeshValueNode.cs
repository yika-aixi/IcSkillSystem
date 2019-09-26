using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/TextMesh Value")]
    public partial class TextMeshValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextMesh _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextMesh);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}