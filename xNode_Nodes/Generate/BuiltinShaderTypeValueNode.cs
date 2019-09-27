using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BuiltinShaderType Value")]
    public partial class BuiltinShaderTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BuiltinShaderType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BuiltinShaderType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}