using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ThreadPriority Value")]
    public partial class ThreadPriorityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ThreadPriority _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ThreadPriority);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}