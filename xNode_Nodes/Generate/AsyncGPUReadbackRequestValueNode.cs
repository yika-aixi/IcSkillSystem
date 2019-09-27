using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AsyncGPUReadbackRequest Value")]
    public partial class AsyncGPUReadbackRequestValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.AsyncGPUReadbackRequest _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.AsyncGPUReadbackRequest);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}