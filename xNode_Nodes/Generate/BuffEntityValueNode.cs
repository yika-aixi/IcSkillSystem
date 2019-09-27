using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/BuffEntity Value")]
    public partial class BuffEntityValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansions.BuffEntity _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansions.BuffEntity);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}