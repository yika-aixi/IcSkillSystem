using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/StencilOp Value")]
    public partial class StencilOpValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.StencilOp _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.StencilOp);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}