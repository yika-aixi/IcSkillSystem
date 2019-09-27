using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextureCompressionQuality Value")]
    public partial class TextureCompressionQualityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextureCompressionQuality _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextureCompressionQuality);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}