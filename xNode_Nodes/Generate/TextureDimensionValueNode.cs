using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextureDimension Value")]
    public partial class TextureDimensionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.TextureDimension _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.TextureDimension);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}