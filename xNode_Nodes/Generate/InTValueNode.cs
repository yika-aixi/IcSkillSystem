using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/InT Value")]
    public partial class InTValueNode:ValueNode
    {
        [SerializeField]
        private Buff.InT _value;

        public override Type ValueType { get; } = typeof(Buff.InT);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}