using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/StencilState Value")]
    public partial class StencilStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.StencilState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.StencilState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}