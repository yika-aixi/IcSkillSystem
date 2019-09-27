using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/Debugger Value")]
    public partial class DebuggerValueNode:ValueNode
    {
        [SerializeField]
        private NPBehave.Debugger _value;

        public override Type ValueType { get; } = typeof(NPBehave.Debugger);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}