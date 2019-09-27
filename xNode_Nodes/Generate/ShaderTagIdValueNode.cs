using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ShaderTagId Value")]
    public partial class ShaderTagIdValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ShaderTagId _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ShaderTagId);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}