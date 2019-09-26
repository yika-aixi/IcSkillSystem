using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/FontStyle Value")]
    public partial class FontStyleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FontStyle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FontStyle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}