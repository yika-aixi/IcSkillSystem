using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/Font Value")]
    public partial class FontValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Font _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Font);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}