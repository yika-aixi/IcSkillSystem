using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CopyTextureSupport Value")]
    public partial class CopyTextureSupportValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CopyTextureSupport _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CopyTextureSupport);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}