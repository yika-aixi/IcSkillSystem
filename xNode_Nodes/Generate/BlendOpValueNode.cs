using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BlendOp Value")]
    public partial class BlendOpValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BlendOp _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BlendOp);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}