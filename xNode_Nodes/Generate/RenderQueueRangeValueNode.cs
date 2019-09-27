using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderQueueRange Value")]
    public partial class RenderQueueRangeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderQueueRange _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderQueueRange);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}