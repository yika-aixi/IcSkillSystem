using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/GroupStart Value")]
    public partial class GroupStartValueNode:ValueNode
    {
        [SerializeField]
        private Buff.GroupStart _value;

        public override Type ValueType { get; } = typeof(Buff.GroupStart);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}