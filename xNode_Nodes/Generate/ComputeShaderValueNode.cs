using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ComputeShader Value")]
    public partial class ComputeShaderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ComputeShader _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ComputeShader);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}