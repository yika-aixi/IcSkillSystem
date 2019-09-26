using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TextureCreationFlags Value")]
    public partial class TextureCreationFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Rendering.TextureCreationFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Rendering.TextureCreationFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}