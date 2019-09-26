using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Expansion/MechanicsType Value")]
    public partial class MechanicsTypeValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components.MechanicsType _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansion.Runtime.Buffs.Components.MechanicsType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}