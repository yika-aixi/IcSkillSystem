using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextureWrapMode Value")]
    public partial class TextureWrapModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextureWrapMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextureWrapMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}