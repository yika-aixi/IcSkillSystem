using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTextureDescriptor Value")]
    public partial class RenderTextureDescriptorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderTextureDescriptor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderTextureDescriptor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}