using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/Operator Value")]
    public partial class OperatorValueNode:ValueNode
    {
        [SerializeField]
        private NPBehave.Operator _value;

        public override Type ValueType { get; } = typeof(NPBehave.Operator);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}