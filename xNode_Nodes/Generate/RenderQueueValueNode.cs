using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderQueue Value")]
    public partial class RenderQueueValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RenderQueue _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RenderQueue);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}