using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BuiltinShaderDefine Value")]
    public partial class BuiltinShaderDefineValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BuiltinShaderDefine _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BuiltinShaderDefine);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}