using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AttachmentDescriptor Value")]
    public partial class AttachmentDescriptorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.AttachmentDescriptor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.AttachmentDescriptor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}