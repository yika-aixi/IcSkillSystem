using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderStateBlock Value")]
    public partial class RenderStateBlockValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderStateBlock _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderStateBlock);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}