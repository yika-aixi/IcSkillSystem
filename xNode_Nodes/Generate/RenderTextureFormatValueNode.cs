using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTextureFormat Value")]
    public partial class RenderTextureFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderTextureFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderTextureFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}