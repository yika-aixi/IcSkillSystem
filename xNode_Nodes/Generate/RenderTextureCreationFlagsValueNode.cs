using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTextureCreationFlags Value")]
    public partial class RenderTextureCreationFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderTextureCreationFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderTextureCreationFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}