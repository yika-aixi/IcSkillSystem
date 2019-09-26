using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BuiltinShaderMode Value")]
    public partial class BuiltinShaderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BuiltinShaderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BuiltinShaderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}