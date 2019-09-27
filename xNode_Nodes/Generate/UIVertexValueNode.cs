using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/UIVertex Value")]
    public partial class UIVertexValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIVertex _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIVertex);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}