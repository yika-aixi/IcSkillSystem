using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/Stops Value")]
    public partial class StopsValueNode:ValueNode
    {
        [SerializeField]
        private NPBehave.Stops _value;

        public override Type ValueType { get; } = typeof(NPBehave.Stops);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}