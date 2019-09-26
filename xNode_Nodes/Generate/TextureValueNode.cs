using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Texture Value")]
    public partial class TextureValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Texture _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Texture);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}