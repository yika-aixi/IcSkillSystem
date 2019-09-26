using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Renderer Value")]
    public partial class RendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Renderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Renderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}