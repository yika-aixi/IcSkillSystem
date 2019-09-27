using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Allocator Value")]
    public partial class AllocatorValueNode:ValueNode
    {
        [SerializeField]
        private Unity.Collections.Allocator _value;

        public override Type ValueType { get; } = typeof(Unity.Collections.Allocator);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}