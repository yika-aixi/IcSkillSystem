using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTextureReadWrite Value")]
    public partial class RenderTextureReadWriteValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderTextureReadWrite _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderTextureReadWrite);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}