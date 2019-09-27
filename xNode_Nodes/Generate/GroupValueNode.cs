using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/Group Value")]
    public partial class GroupValueNode:ValueNode
    {
        [SerializeField]
        private Group _value;

        public override Type ValueType { get; } = typeof(Group);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}