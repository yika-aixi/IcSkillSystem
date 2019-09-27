using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/CabinIcarus/IcSkillSystem/Runtime/BuffEntityLinkComponent Value")]
    public partial class BuffEntityLinkComponentValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity.BuffEntityLinkComponent _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity.BuffEntityLinkComponent);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}