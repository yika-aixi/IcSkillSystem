using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BuiltinRenderTextureType Value")]
    public partial class BuiltinRenderTextureTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BuiltinRenderTextureType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BuiltinRenderTextureType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}