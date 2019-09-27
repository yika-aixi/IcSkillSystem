using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShaderKeywordType Value")]
    public partial class ShaderKeywordTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShaderKeywordType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShaderKeywordType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}