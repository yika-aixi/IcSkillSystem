using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ComputeQueueType Value")]
    public partial class ComputeQueueTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ComputeQueueType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ComputeQueueType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}