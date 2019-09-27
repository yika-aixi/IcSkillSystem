using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/IcSkillSystem/Expansion/Runtime/AttributeType Value")]
    public partial class AttributeTypeValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components.AttributeType _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components.AttributeType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}