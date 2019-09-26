using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/StackTraceLogType Value")]
    public partial class StackTraceLogTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.StackTraceLogType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.StackTraceLogType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}