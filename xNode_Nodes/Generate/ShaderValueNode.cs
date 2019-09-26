using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Shader Value")]
    public partial class ShaderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Shader _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Shader);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}