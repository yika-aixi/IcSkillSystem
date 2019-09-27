using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextureFormat Value")]
    public partial class TextureFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextureFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextureFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}