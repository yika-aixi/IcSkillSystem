using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShaderKeywordSet Value")]
    public partial class ShaderKeywordSetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShaderKeywordSet _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShaderKeywordSet);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}