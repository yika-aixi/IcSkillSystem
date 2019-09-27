using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderStateMask Value")]
    public partial class RenderStateMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderStateMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderStateMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}